using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Comments.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Update
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, IDataResult<CommentDTO>>
	{
        private ICommentService _commentService;
        CommentBusinessRules _commentBusinessRules;
        UserBusinessRules _userBusinessRules;

        public UpdateCommentCommandHandler(ICommentService commentService, CommentBusinessRules commentBusinessRules, UserBusinessRules userBusinessRules)
        {
            _commentService = commentService;
            _commentBusinessRules = commentBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<CommentDTO>> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            await _commentBusinessRules.IsCommentExistAsync(request.Id);
            await _commentBusinessRules.IsCommentActiveAsync(request.Id);
            await _commentBusinessRules.IsOwnerCorrectAsync(request.Id, request.UserId);
            CommentDTO commentDTO = await _commentService.UpdateAsync(request.Adapt<UpdateCommentDTO>());
            return new SuccessDataResult<CommentDTO>(request.Id + " Yorum Güncellendi", commentDTO);
        }
    }
}

