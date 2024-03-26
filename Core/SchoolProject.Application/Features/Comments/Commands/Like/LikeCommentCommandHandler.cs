using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.Commands.Add;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Like
{
    public class LikeCommentCommandHandler : IRequestHandler<LikeCommentCommandRequest, IDataResult<CommentDTO>>
    {
        private ICommentService _commentService;
        public LikeCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IDataResult<CommentDTO>> Handle(LikeCommentCommandRequest request, CancellationToken cancellationToken)
        {
            CommentDTO commentDTO = await _commentService.LikeAsync(request.Id,request.UserId);
            var data = new SuccessDataResult<CommentDTO>(request.Id + " Yorumu begenildi", commentDTO);
            return data;
        }
    }
}

