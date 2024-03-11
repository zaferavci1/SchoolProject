using System;
using MediatR;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Add
{
	public class AddCommentCommandRequest : IRequest<IDataResult<CommentDTO>>
	{
        public string PostId { get; set; }
        public string Content { get; set; }
    }
}

