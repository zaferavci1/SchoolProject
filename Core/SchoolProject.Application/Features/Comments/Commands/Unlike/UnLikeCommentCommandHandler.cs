using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.Commands.Like;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Unlike
{
	public class UnLikeCommentCommandHandler : IRequestHandler<UnLikeCommentCommandRequest, IDataResult<CommentDTO>>
    {
        private ICommentService _commentService;
        public UnLikeCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IDataResult<CommentDTO>> Handle(UnLikeCommentCommandRequest request, CancellationToken cancellationToken)
        {
            CommentDTO commentDTO = await _commentService.UnLikeAsync(request.Id, request.UserId);
            var data = new SuccessDataResult<CommentDTO>(request.Id + " Yorumu begenildi", commentDTO);
            return data;
        }
    }
}

