using System;
using MediatR;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Update
{
	public class UpdateCommentCommandRequest : IRequest<IDataResult<CommentDTO>>
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}

