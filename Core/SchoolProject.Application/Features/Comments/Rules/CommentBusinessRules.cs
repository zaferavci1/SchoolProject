using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Comments;
using SchoolProject.Application.Abstraction.Repository.Posts;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Exceptions;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Comments.Rules
{
	public class CommentBusinessRules
	{
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly ICommentQueryRepository _commentQueryRepository;
        private readonly IDataProtector _userDataProtector;
        private readonly IDataProtector _postDataProtector;
        private readonly IDataProtector _commentDataProtector;
        public CommentBusinessRules(IUserQueryRepository userQueryRepository, IPostQueryRepository postQueryRepository, IDataProtectionProvider dataProtectionProvider, ICommentQueryRepository commentQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
            _commentQueryRepository = commentQueryRepository;
            _userDataProtector = dataProtectionProvider.CreateProtector("Users");
            _postDataProtector = dataProtectionProvider.CreateProtector("Posts");
            _commentDataProtector = dataProtectionProvider.CreateProtector("Comments");
        }
        public async Task IsCommentExist(string id)
        {
            Comment? comment = await _commentQueryRepository.GetByIdAsync(_commentDataProtector.Unprotect(id));
            if (comment == null) throw new CustomException<CommentDTO>("Comment Not Exist");
        }
        public async Task IsCommentActive(string id)
        {
            Comment? comment = await _commentQueryRepository.GetByIdAsync(_commentDataProtector.Unprotect(id));
            if (!comment.IsActive) throw new CustomException<CommentDTO>("Comment Not Active");
        }
        public async Task IsCommentLiked(string commentId, string userId)
        {
            bool check = await _userQueryRepository.Table.AnyAsync(u => u.CommentLikes.Any(cl => cl.UserId == Guid.Parse(_userDataProtector.Unprotect(userId)) && cl.CommentId == Guid.Parse(_commentDataProtector.Unprotect(commentId))));
            if (!check) throw new CustomException<CommentDTO>("Comment Not Liked");

        }
        public async Task IsCommentAllreadyLiked(string commentId, string userId)
        {
            bool check = await _userQueryRepository.Table.AnyAsync(u => u.CommentLikes.Any(cl => cl.UserId == Guid.Parse(_userDataProtector.Unprotect(userId)) && cl.CommentId == Guid.Parse(_commentDataProtector.Unprotect(commentId))));
            if (check) throw new CustomException<CommentDTO>("Comment Allready Liked");
        }
        public async Task IsOwnerCorrect(string commentId, string userId)
        {
            Comment? comment = await _commentQueryRepository.GetByIdAsync(_postDataProtector.Unprotect(commentId));
            if (comment.UserId != Guid.Parse(_userDataProtector.Unprotect(userId))) throw new CustomException<CommentDTO>("Owner Not Correct");
        }
    }
}