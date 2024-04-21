using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Update
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, IDataResult<CommentDTO>>
	{
        private ICommentService _commentService;
        public UpdateCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IDataResult<CommentDTO>> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            CommentDTO commentDTO = await _commentService.UpdateAsync(request.Adapt<UpdateCommentDTO>());
            return new SuccessDataResult<CommentDTO>(request.Id + " Yorum Güncellendi", commentDTO);
        }
    }
}

