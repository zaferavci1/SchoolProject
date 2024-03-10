using System;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Comments;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services
{
	public class CommentService : ICommentService
	{
        private readonly ICommentQueryRepository _commentQueryRepository;
        private readonly ICommentCommandRepository _commentCommandRepository;
        public CommentService(ICommentQueryRepository commentQueryRepository, ICommentCommandRepository commentCommandRepository)
        {
            _commentQueryRepository = commentQueryRepository;
            _commentCommandRepository = commentCommandRepository;
        }

        public async Task<CommentDTO> AddAsync(AddCommentDTO addCommentDTO)
        {
            Comment comment = await _commentCommandRepository.AddAsync(new() { Content = addCommentDTO.Content });
            await _commentCommandRepository.SaveAsync();
            return new() {PostId=Convert.ToString(comment.PostID), Id = Convert.ToString(comment.Id), Content = comment.Content };

        }

        public async Task<CommentDTO> DeleteAsync(string id)
        {
            Comment comment = await _commentCommandRepository.RemoveAsync(id);
            await _commentCommandRepository.SaveAsync();
            return new() { PostId = Convert.ToString(comment.PostID), Id = id, Content = comment.Content };
        }

        public async Task<(List<GetAllCommentsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => (await _commentQueryRepository.GetAll().Where(c => c.IsActive == true).Include(c => c.ReplyComments).Skip(page * size).Take(size).Select(c => new GetAllCommentsDTO()
            {
                Id = Convert.ToString(c.Id),
                Content = c.Content,
                LikeCount = c.LikeCount,
                ReplyComments = c.ReplyComments.Select(x => new CommentDTO() { PostId = Convert.ToString(c.PostID), Id = Convert.ToString(x.Id), Content = x.Content, LikeCount = x.LikeCount }).ToList()
            }).ToListAsync(), _commentQueryRepository.GetAll().Count() );

        

        public async Task<GetByIdCommentDTO> GetByIdAsync(string id)
        {
            Comment comment = await _commentQueryRepository.Table.Include(c =>c.ReplyComments).FirstOrDefaultAsync(c=>c.Id == Guid.Parse(id));

            return new()
            {
                Id = id,
                Content = comment.Content,
                LikeCount = comment.LikeCount,
                ReplyComments = comment.ReplyComments.Select(x => new CommentDTO()
                {
                    PostId = Convert.ToString(x.PostID),
                    Id = Convert.ToString(x.Id),
                    Content = x.Content,
                    LikeCount = x.LikeCount
                }).ToList()
            };
        }

        public async Task<CommentDTO> UpdateAsync(UpdateCommentDTO updateCommentDTO)
        {
            Comment comment = await _commentQueryRepository.GetByIdAsync(updateCommentDTO.Id);
            comment.IsActive = updateCommentDTO.IsActive;
            comment.Content = updateCommentDTO.Content;
            _commentCommandRepository.Update(comment);
            _commentCommandRepository.SaveAsync();
            return new CommentDTO() { PostId = Convert.ToString(comment.PostID), Id = Convert.ToString(comment.Id), Content = comment.Content };
        }
    }
}

