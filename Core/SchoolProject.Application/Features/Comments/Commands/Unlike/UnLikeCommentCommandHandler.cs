using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.Commands.Like;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Comments.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Unlike
{
	public class UnLikeCommentCommandHandler : IRequestHandler<UnLikeCommentCommandRequest, IDataResult<CommentDTO>>
    {
        private ICommentService _commentService;
        CommentBusinessRules _commentBusinessRules;
        UserBusinessRules _userBusinessRules;

        public UnLikeCommentCommandHandler(ICommentService commentService, CommentBusinessRules commentBusinessRules, UserBusinessRules userBusinessRules)
        {
            _commentService = commentService;
            _commentBusinessRules = commentBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<CommentDTO>> Handle(UnLikeCommentCommandRequest request, CancellationToken cancellationToken)
        {

            await _userBusinessRules.IsUserExist(request.UserId);
            await _userBusinessRules.IsUserActive(request.UserId);
            await _commentBusinessRules.IsCommentExist(request.Id);
            await _commentBusinessRules.IsCommentActive(request.Id);
            await _commentBusinessRules.IsCommentLiked(request.Id, request.UserId);

            CommentDTO commentDTO = await _commentService.UnLikeAsync(request.Id, request.UserId);
            var data = new SuccessDataResult<CommentDTO>(request.Id + " Yorumu begenildi", commentDTO);
            return data;
        }
    }
}

