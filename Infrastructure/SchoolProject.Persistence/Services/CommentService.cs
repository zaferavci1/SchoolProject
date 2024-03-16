using System;
using Microsoft.AspNetCore.DataProtection;
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
        private readonly IDataProtector dataProtector;
        private readonly IDataProtector postDataProtector;

        public CommentService(ICommentQueryRepository commentQueryRepository, ICommentCommandRepository commentCommandRepository , IDataProtectionProvider dataProtectionProvider)
        {
            _commentQueryRepository = commentQueryRepository;
            _commentCommandRepository = commentCommandRepository;
            dataProtector = dataProtectionProvider.CreateProtector("Comments");
            postDataProtector = dataProtectionProvider.CreateProtector("Posts");
        }

        public async Task<CommentDTO> AddAsync(AddCommentDTO addCommentDTO)
        {
            Comment comment = await _commentCommandRepository.AddAsync(new() { PostID = Guid.Parse(postDataProtector.Unprotect(addCommentDTO.PostId)), Content = addCommentDTO.Content });
            await _commentCommandRepository.SaveAsync();
            return new()
            {
                PostId = postDataProtector.Protect(comment.PostID.ToString()),
                Id = dataProtector.Protect(comment.Id.ToString()),
                Content = comment.Content
            };

        }

        public async Task<CommentDTO> DeleteAsync(string id)
        {
            Comment comment = await _commentCommandRepository.RemoveAsync(dataProtector.Unprotect(id));
            await _commentCommandRepository.SaveAsync();
            return new()
            {
                PostId = postDataProtector.Protect(comment.PostID.ToString()),
                Id = dataProtector.Protect(comment.Id.ToString()),
                Content = comment.Content
            };
        }

        public async Task<(List<GetAllCommentsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => (await _commentQueryRepository.GetAll().Where(c => c.IsActive == true).Include(c => c.ReplyComments).Skip(page * size).Take(size).Select(c => new GetAllCommentsDTO()
            {
                Id =dataProtector.Protect(c.Id.ToString()),
                Content = c.Content,
                LikeCount = c.LikeCount,
                ReplyComments = c.ReplyComments.Select(x => new CommentDTO()
                {
                    PostId = postDataProtector.Protect(x.PostID.ToString()),
                    Id = dataProtector.Protect(x.Id.ToString()),
                    Content = x.Content,
                    LikeCount = x.LikeCount
                }).ToList()
            }).ToListAsync(), _commentQueryRepository.GetAll().Count() );

        

        public async Task<GetByIdCommentDTO> GetByIdAsync(string id)
        {
            Comment comment = await _commentQueryRepository.Table.Include(c =>c.ReplyComments).FirstOrDefaultAsync(c=>c.Id == Guid.Parse(dataProtector.Unprotect(id)));

            return new()
            {
                Id = id,
                Content = comment.Content,
                LikeCount = comment.LikeCount,
                ReplyComments = comment.ReplyComments.Select(x => new CommentDTO()
                {
                    PostId = postDataProtector.Protect(x.PostID.ToString()),
                    Id = dataProtector.Protect(x.Id.ToString()),
                    Content = x.Content,
                    LikeCount = x.LikeCount
                }).ToList() ?? new List<CommentDTO>()
            };
        }

        public async Task<CommentDTO> UpdateAsync(UpdateCommentDTO updateCommentDTO)
        {
            Comment comment = await _commentQueryRepository.GetByIdAsync(dataProtector.Unprotect(updateCommentDTO.Id));
            comment.IsActive = updateCommentDTO.IsActive;
            comment.Content = updateCommentDTO.Content;
            _commentCommandRepository.Update(comment);
            _commentCommandRepository.SaveAsync();
            return new()
            {
                PostId = postDataProtector.Protect(comment.PostID.ToString()),
                Id = dataProtector.Protect(comment.Id.ToString()),
                Content = comment.Content
            };
        }
    }
}

