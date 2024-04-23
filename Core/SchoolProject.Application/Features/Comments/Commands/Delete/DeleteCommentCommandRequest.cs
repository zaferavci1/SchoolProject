using System;
using MediatR;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Delete
{
	public class DeleteCommentCommandRequest : IRequest<IDataResult<CommentDTO>>
    {
        public string UserId { get; set; }
        public string Id { get; set; }
    }
}

