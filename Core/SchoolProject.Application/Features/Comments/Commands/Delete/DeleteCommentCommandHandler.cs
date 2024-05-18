using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Comments.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, IDataResult<CommentDTO>>
    {
        private ICommentService _commentService;
        CommentBusinessRules _commentBusinessRules;
        UserBusinessRules _userBusinessRules;

        public DeleteCommentCommandHandler(ICommentService commentService, CommentBusinessRules commentBusinessRules, UserBusinessRules userBusinessRules)
        {
            _commentService = commentService;
            _commentBusinessRules = commentBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<CommentDTO>> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            await _commentBusinessRules.IsCommentExistAsync(request.Id);
            await _commentBusinessRules.IsCommentActiveAsync(request.Id);
            await _commentBusinessRules.IsOwnerCorrectAsync(request.Id, request.UserId);
            CommentDTO commentDTO = await _commentService.DeleteAsync(request.Id);
            return new SuccessDataResult<CommentDTO>(commentDTO.Id + " Yorum Silindi.", commentDTO);
        }
    }
}

