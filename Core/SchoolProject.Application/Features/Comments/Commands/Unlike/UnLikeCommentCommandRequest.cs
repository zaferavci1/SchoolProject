using System;
using MediatR;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Commands.Unlike
{
	public class UnLikeCommentCommandRequest : IRequest<IDataResult<CommentDTO>>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}

