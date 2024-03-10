using System;
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

        public PostService(IPostCommandRepository postCommandRepository, IPostQueryRepository postQueryRepository)
        {
            _postCommandRepository = postCommandRepository;
            _postQueryRepository = postQueryRepository;
        }


        public async Task<PostDTO> AddAsync(AddPostDTO addPostDTO)
        {
            Post post = await _postCommandRepository.AddAsync(new() { Title = addPostDTO.Title, Content = addPostDTO.Content });
            await _postCommandRepository.SaveAsync();
            return new() { Id = Convert.ToString(post.Id), Content = post.Content, Title = post.Content };
        }

        public async Task<PostDTO> DeleteAsync(string id)
        {
            Post post = await _postCommandRepository.RemoveAsync(Convert.ToString(id));
            await _postCommandRepository.SaveAsync();
            return new() { Id = Convert.ToString(post.Id), Content = post.Content, Title = post.Content };
            return new() { UserId =Convert.ToString( post.UserId), Id = Convert.ToString(post.Id), Content = post.Content, Title = post.Content };
        }
        

        public async Task<(List<GetAllPostsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => (await _postQueryRepository.GetAll().Where(p => p.IsActive == true).Include(p => p.Comments).Skip(page * size).Take(size).Select(p => new GetAllPostsDTO
        {
            Id = Convert.ToString(p.Id),
            Comments = p.Comments.Select( c => new CommentDTO {Content = c.Content, Id = Convert.ToString(c.Id) , LikeCount = c.LikeCount , PostId=Convert.ToString(c.PostID)}).ToList(),
            Title = p.Title,
            Content = p.Content
        }).ToListAsync(), await _postQueryRepository.GetAll().CountAsync());

        public async Task<GetByIdPostDTO> GetByIdAsync(string id)
        {
            Post post = await _postQueryRepository.Table.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            return new() { Id = Convert.ToInt32(post.Id), Comments = post.Comments, Content = post.Content, Title = post.Title };
        }

        public async Task<PostDTO> UpdateAsync(UpdatePostDTO updatePostDTO)
        {
            Post post = await _postQueryRepository.GetByIdAsync(updatePostDTO.Id);
            post.Title = updatePostDTO.Title;
            post.Content = updatePostDTO.Content;
            post.IsActive = updatePostDTO.IsActive;
            return new() { UserId = Convert.ToString(post.UserId), Id = Convert.ToString(post.Id), Content = post.Content, Title = post.Title };

        }
    }
}

