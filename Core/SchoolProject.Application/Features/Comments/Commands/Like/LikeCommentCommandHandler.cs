using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.Commands.Add;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Comments.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Like
{
    public class LikeCommentCommandHandler : IRequestHandler<LikeCommentCommandRequest, IDataResult<CommentDTO>>
    {
        private ICommentService _commentService;
        CommentBusinessRules _commentBusinessRules;
        UserBusinessRules _userBusinessRules;

        public LikeCommentCommandHandler(ICommentService commentService, CommentBusinessRules commentBusinessRules, UserBusinessRules userBusinessRules)
        {
            _commentService = commentService;
            _commentBusinessRules = commentBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<CommentDTO>> Handle(LikeCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            await _commentBusinessRules.IsCommentExistAsync(request.Id);
            await _commentBusinessRules.IsCommentActiveAsync(request.Id);
            await _commentBusinessRules.IsCommentAllreadyLikedAsync(request.Id,request.UserId);
            CommentDTO commentDTO = await _commentService.LikeAsync(request.Id,request.UserId);
            var data = new SuccessDataResult<CommentDTO>(request.Id + " Yorumu begenildi", commentDTO);
            return data;
        }
    }
}

