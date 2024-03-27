using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Comments;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Services
{
    public class CommentService : ICommentService
	{
        private readonly ICommentQueryRepository _commentQueryRepository;
        private readonly ICommentCommandRepository _commentCommandRepository;
        private readonly IDataProtector commentdataProtector;
        private readonly IDataProtector postDataProtector;
        private readonly IDataProtector userDataProtector;
        private readonly SchoolProjectDbContext _context;

        public CommentService(ICommentQueryRepository commentQueryRepository, ICommentCommandRepository commentCommandRepository, IDataProtectionProvider dataProtectionProvider, SchoolProjectDbContext context)
        {
            _commentQueryRepository = commentQueryRepository;
            _commentCommandRepository = commentCommandRepository;
            commentdataProtector = dataProtectionProvider.CreateProtector("Comments");
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
            postDataProtector = dataProtectionProvider.CreateProtector("Posts");
            _context = context;
        }

        public async Task<CommentDTO> AddAsync(AddCommentDTO addCommentDTO)
        {
            Comment comment = await _commentCommandRepository.AddAsync(new() {UserId = Guid.Parse(userDataProtector.Unprotect(addCommentDTO.UserId)),
                PostId = Guid.Parse(postDataProtector.Unprotect(addCommentDTO.PostId)), Content = addCommentDTO.Content });
            await _commentCommandRepository.SaveAsync();
            return new()
            {
                UserId = userDataProtector.Protect(comment.UserId.ToString()),
                PostId = postDataProtector.Protect(comment.PostId.ToString()),
                Id = commentdataProtector.Protect(comment.Id.ToString()),
                Content = comment.Content,
                LikeCount = comment.LikeCount
            };

        }

        public async Task<CommentDTO> DeleteAsync(string id)
        {
            Comment comment = await _commentCommandRepository.RemoveAsync(commentdataProtector.Unprotect(id));
            await _commentCommandRepository.SaveAsync();
            return new()
            {
                UserId = userDataProtector.Protect(comment.UserId.ToString()),
                PostId = postDataProtector.Protect(comment.PostId.ToString()),
                Id = commentdataProtector.Protect(comment.Id.ToString()),
                Content = comment.Content,
                LikeCount = comment.LikeCount
            };
        }

        public async Task<(List<GetAllCommentsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => (await _commentQueryRepository.GetAll().Where(c => c.IsActive == true).Include(c => c.ReplyComments).Skip(page * size).Take(size).Select(c => new GetAllCommentsDTO()
            {

                Id =commentdataProtector.Protect(c.Id.ToString()),
                Content = c.Content,
                LikeCount = c.LikeCount,
                UserId = userDataProtector.Protect(c.UserId.ToString()),
                PostId = postDataProtector.Protect(c.PostId.ToString()),
            ReplyComments = c.ReplyComments.Select(x => new CommentDTO()
                {
                    PostId = postDataProtector.Protect(x.PostId.ToString()),
                    Id = commentdataProtector.Protect(x.Id.ToString()),
                    Content = x.Content,
                    LikeCount = x.LikeCount
                }).ToList()
            }).ToListAsync(), _commentQueryRepository.GetAll().Count() );

        

        public async Task<GetByIdCommentDTO> GetByIdAsync(string id)
        {
            Comment comment = await _commentQueryRepository.Table.Include(c =>c.ReplyComments).FirstOrDefaultAsync(c=>c.Id == Guid.Parse(commentdataProtector.Unprotect(id)));

            return new()
            {
                Id = id,
                UserId = userDataProtector.Protect(comment.UserId.ToString()),
                PostId = postDataProtector.Protect(comment.PostId.ToString()),
                Content = comment.Content,
                LikeCount = comment.LikeCount,
                ReplyComments = comment.ReplyComments.Select(x => new CommentDTO()
                {
                    UserId = userDataProtector.Protect(x.UserId.ToString()),
                    PostId = postDataProtector.Protect(x.PostId.ToString()),
                    Id = commentdataProtector.Protect(x.Id.ToString()),
                    Content = x.Content,
                    LikeCount = x.LikeCount
                }).ToList() ?? new List<CommentDTO>()
            };
        }

        public async Task<CommentDTO> LikeAsync(string id,string userId)
        {
            Comment comment = await _commentQueryRepository.GetByIdAsync(commentdataProtector.Unprotect(id));
            CommentLike cl = new()
            {
                CommentId = Guid.Parse(commentdataProtector.Unprotect(id)),
                UserId = Guid.Parse(userDataProtector.Unprotect(userId))
            };
            comment.LikeCount -= 1;
            _context.CommentLikes.Add(cl);
            _commentCommandRepository.Update(comment);
            await _commentCommandRepository.SaveAsync();
            return new()
            {
                UserId = userDataProtector.Protect(comment.UserId.ToString()),
                PostId = postDataProtector.Protect(comment.PostId.ToString()),
                Id = commentdataProtector.Protect(comment.Id.ToString()),
                Content = comment.Content,
                LikeCount = comment.LikeCount
            };
        }

        public async Task<CommentDTO> UnLikeAsync(string id, string userId)
        {
            Comment comment = await _commentQueryRepository.GetByIdAsync(commentdataProtector.Unprotect(id));
            comment.LikeCount -= 1;
            CommentLike cl = new()
            {
                CommentId = Guid.Parse(commentdataProtector.Unprotect(id)),
                UserId = Guid.Parse(userDataProtector.Unprotect(userId))
            };
            _context.CommentLikes.Remove(cl);
            _commentCommandRepository.Update(comment);
            await _commentCommandRepository.SaveAsync();
            return new()
            {
                UserId = userDataProtector.Protect(comment.UserId.ToString()),
                PostId = postDataProtector.Protect(comment.PostId.ToString()),
                Id = commentdataProtector.Protect(comment.Id.ToString()),
                Content = comment.Content,
                LikeCount = comment.LikeCount
            };
        }

        public async Task<CommentDTO> UpdateAsync(UpdateCommentDTO updateCommentDTO)
        {
            Comment comment = await _commentQueryRepository.GetByIdAsync(commentdataProtector.Unprotect(updateCommentDTO.Id));
            comment.IsActive = updateCommentDTO.IsActive;
            comment.Content = updateCommentDTO.Content;
            _commentCommandRepository.Update(comment);
            await _commentCommandRepository.SaveAsync();
            return new()
            {

                UserId = userDataProtector.Protect(comment.UserId.ToString()),
                PostId = postDataProtector.Protect(comment.PostId.ToString()),
                Id = commentdataProtector.Protect(comment.Id.ToString()),
                Content = comment.Content,
                LikeCount = comment.LikeCount
            };
        }
    }
}

