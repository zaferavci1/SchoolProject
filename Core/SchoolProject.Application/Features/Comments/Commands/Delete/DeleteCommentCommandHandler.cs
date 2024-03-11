using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, IDataResult<CommentDTO>>
    {
        private ICommentService _commentService;
        public DeleteCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IDataResult<CommentDTO>> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            CommentDTO commentDTO = await _commentService.DeleteAsync(request.Id);
            return new SuccessDataResult<CommentDTO>(commentDTO.Id + " Yorum Silindi.", commentDTO);
        }
    }
}

