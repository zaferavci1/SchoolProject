﻿using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Posts;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Services
{
    public class PostService : IPostService
	{
        private readonly IPostCommandRepository _postCommandRepository;
        private readonly IPostQueryRepository _postQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IDataProtector postDataProtector;
        private readonly IDataProtector userDataProtector;
        private readonly IDataProtector commentDataProtector;
        private readonly SchoolProjectDbContext _dbContext;


        public PostService(IPostCommandRepository postCommandRepository, IPostQueryRepository postQueryRepository, IDataProtectionProvider dataProtectionProvider, SchoolProjectDbContext dbContext, IUserQueryRepository userQueryRepository)
        {
            _postCommandRepository = postCommandRepository;
            _postQueryRepository = postQueryRepository;
            _userQueryRepository = userQueryRepository;
            postDataProtector = dataProtectionProvider.CreateProtector("Posts");
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
            commentDataProtector = dataProtectionProvider.CreateProtector("Comments");
            _dbContext = dbContext;
        }


        public async Task<PostDTO> AddAsync(AddPostDTO addPostDTO)
        {
            Post post = await _postCommandRepository.AddAsync(new() { UserId = Guid.Parse(userDataProtector.Unprotect(addPostDTO.UserId)),Title = addPostDTO.Title, Content = addPostDTO.Content });
            await _postCommandRepository.SaveAsync();
            return new()
            {
                UserId = userDataProtector.Protect(post.UserId.ToString()),
                Id = postDataProtector.Protect(post.Id.ToString()),
                Content = post.Content,
                Title = post.Title,
                LikeCount = post.LikeCount,
                CreatedDate = post.CreatedDate
            };
        }

        public async Task<PostDTO> DeleteAsync(string id)
        {
            Post post = await _postCommandRepository.RemoveAsync(postDataProtector.Unprotect(id));
            await _postCommandRepository.SaveAsync();
            return new()
            {
                UserId = userDataProtector.Protect(post.UserId.ToString()),
                Id = postDataProtector.Protect(post.Id.ToString()),
                Content = post.Content,
                Title = post.Title,
                LikeCount = post.LikeCount,
                CreatedDate = post.CreatedDate
            };
        }


        public async Task<(List<GetAllPostsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => (await _postQueryRepository.GetAll().Where(p => p.IsActive == true).Include(p=>p.User).Include(p => p.Comments).ThenInclude(c=>c.User).Skip(page * size).Take(size).Select(p => new GetAllPostsDTO
        {
            UserId = userDataProtector.Protect(p.UserId.ToString()),
            Id = postDataProtector.Protect(p.Id.ToString()),
            OwnersName = p.User.NickName,
            ProfilePictureId = p.User.ProfilePictureId,
            Comments = p.Comments.Select(c => new CommentDTO
            {
                UserId =userDataProtector.Protect(c.UserId.ToString()),
                PostId = postDataProtector.Protect(c.PostId.ToString()),
                Id = commentDataProtector.Protect(c.Id.ToString()),
                Content = c.Content,
                LikeCount = c.LikeCount,
                CreatedDate = c.CreatedDate,
                OwnersName = c.User.NickName,
                ProfilePictureId = c.User.ProfilePictureId
            }).ToList(),
            Title = p.Title,
            Content = p.Content,
            LikeCount = p.LikeCount,
            CreatedDate = p.CreatedDate,
        }).ToListAsync(), await _postQueryRepository.GetAll().CountAsync());

        public async Task<GetByIdPostDTO> GetByIdAsync(string id)
        {
            Post post = await _postQueryRepository.Table.Include(p=>p.User).Include(p => p.Comments).ThenInclude(c=>c.User).FirstOrDefaultAsync(p => p.Id == Guid.Parse(postDataProtector.Unprotect(id)));
            return new()
            {
                UserId = userDataProtector.Protect(post.UserId.ToString()),
                Id = postDataProtector.Protect(post.Id.ToString()),
                Comments = post.Comments.Select(c => new CommentDTO()
                {
                    UserId = userDataProtector.Protect(c.UserId.ToString()),
                    PostId = postDataProtector.Protect(c.PostId.ToString()),
                    Id = commentDataProtector.Protect(c.Id.ToString()),
                    Content = c.Content,
                    LikeCount = c.LikeCount,
                    CreatedDate = c.CreatedDate,
                    OwnersName = c.User.NickName,
                    ProfilePictureId = c.User.ProfilePictureId
                }).ToList() ?? new List<CommentDTO>(),
                Content = post.Content,
                Title = post.Title,
                likeCount = post.LikeCount,
                CreatedDate = post.CreatedDate,
                OwnersName = post.User.NickName,
                ProfilePictureId = post.User.ProfilePictureId,
            };
        }

        public async Task<PostDTO> LikeAsync(string id,string userId)
        {
            Post post = await _postQueryRepository.GetByIdAsync(postDataProtector.Unprotect(id));
            post.LikeCount += 1;
            PostLike pl = new()
            {
                PostId = Guid.Parse(postDataProtector.Unprotect(id)),
                UserId = Guid.Parse(userDataProtector.Unprotect(userId))
            };
            _postCommandRepository.Update(post);

            await _dbContext.PostLikes.AddAsync(pl);

            await _postCommandRepository.SaveAsync();
            return new()
            {
                UserId = userDataProtector.Protect(post.UserId.ToString()),
                Id = postDataProtector.Protect(post.Id.ToString()),
                Content = post.Content,
                Title = post.Content,
                LikeCount = post.LikeCount,
                CreatedDate = post.CreatedDate
            };
        }

        public async Task<PostDTO> UnLikeAsync(string id, string userId)
        {
            Post post = await _postQueryRepository.GetByIdAsync(postDataProtector.Unprotect(id));
            PostLike pl = new()
            {
                PostId = Guid.Parse(postDataProtector.Unprotect(id)),
                UserId = Guid.Parse(userDataProtector.Unprotect(userId))
            };

            _dbContext.PostLikes.Remove(pl);
            post.LikeCount -= 1;
            _postCommandRepository.Update(post);

            await _postCommandRepository.SaveAsync();
            return new()
            {
                UserId = userDataProtector.Protect(post.UserId.ToString()),
                Id = postDataProtector.Protect(post.Id.ToString()),
                Content = post.Content,
                Title = post.Content,
                LikeCount = post.LikeCount,
                CreatedDate = post.CreatedDate
            };
        }

        public async Task<PostDTO> UpdateAsync(UpdatePostDTO updatePostDTO)
        {
            Post post = await _postQueryRepository.GetByIdAsync(postDataProtector.Unprotect(updatePostDTO.Id));
            post.Title = updatePostDTO.Title;
            post.Content = updatePostDTO.Content;
            post.IsActive = updatePostDTO.IsActive;
            _postCommandRepository.Update(post);    
            await _postCommandRepository.SaveAsync();
            return new()
            {
                UserId = userDataProtector.Protect(post.UserId.ToString()),
                Id = postDataProtector.Protect(post.Id.ToString()),
                Content = post.Content,
                Title = post.Content,
                LikeCount = post.LikeCount,
                CreatedDate = post.CreatedDate
            };
        }
    }
}

