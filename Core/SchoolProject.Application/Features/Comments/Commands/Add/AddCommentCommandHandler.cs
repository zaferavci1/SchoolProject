using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Add
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommandRequest, IDataResult<CommentDTO>>
    {
        private ICommentService _commentService;
        public AddCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IDataResult<CommentDTO>> Handle(AddCommentCommandRequest request, CancellationToken cancellationToken)
        {
            CommentDTO commentDTO = await _commentService.AddAsync(new() {UserId= request.UserId, PostId = request.PostId, Content = request.Content });
            var data = new SuccessDataResult<CommentDTO>(request.PostId + " 'a yorum eklendi", commentDTO);
            return data;
        }


    }
}

