using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Posts;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services
{
	public class PostService : IPostService
	{
        private readonly IPostCommandRepository _postCommandRepository;
        private readonly IPostQueryRepository _postQueryRepository;
        private readonly IDataProtector postDataProtector;
        private readonly IDataProtector userDataProtector;
        private readonly IDataProtector commentDataProtector;


        public PostService(IPostCommandRepository postCommandRepository, IPostQueryRepository postQueryRepository,IDataProtectionProvider dataProtectionProvider)
        {
            _postCommandRepository = postCommandRepository;
            _postQueryRepository = postQueryRepository;
            postDataProtector = dataProtectionProvider.CreateProtector("Posts");
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
            commentDataProtector = dataProtectionProvider.CreateProtector("Comments");
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
                Title = post.Title
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
                Title = post.Title
            };
        }


        public async Task<(List<GetAllPostsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => (await _postQueryRepository.GetAll().Where(p => p.IsActive == true).Include(p => p.Comments).Skip(page * size).Take(size).Select(p => new GetAllPostsDTO
        {
            UserId = userDataProtector.Protect(p.UserId.ToString()),
            Id = postDataProtector.Protect(p.Id.ToString()),
            Comments = p.Comments.Select(c => new CommentDTO
            {
                UserId =userDataProtector.Protect(c.UserId.ToString()),
                PostId = postDataProtector.Protect(c.PostID.ToString()),
                Id = commentDataProtector.Protect(c.Id.ToString()),
                Content = c.Content,
                LikeCount = c.LikeCount
            }).ToList(),
            Title = p.Title,
            Content = p.Content
        }).ToListAsync(), await _postQueryRepository.GetAll().CountAsync());

        public async Task<GetByIdPostDTO> GetByIdAsync(string id)
        {
            Post post = await _postQueryRepository.Table.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == Guid.Parse(postDataProtector.Unprotect(id)));
            return new()
            {
                Id = postDataProtector.Protect(post.Id.ToString()),
                Comments = post.Comments.Select(c => new CommentDTO()
                {
                    UserId = userDataProtector.Protect(c.UserId.ToString()),
                    PostId = postDataProtector.Protect(c.PostID.ToString()),
                    Id = commentDataProtector.Protect(c.Id.ToString()),
                    Content = c.Content,
                }).ToList() ?? new List<CommentDTO>(),
                Content = post.Content,
                Title = post.Title
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
                Title = post.Content
            };
        }
    }
}

