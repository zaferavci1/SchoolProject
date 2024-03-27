using System;
using MediatR;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.UnLike
{
	public class UnLikePostCommandRequest: IRequest<IDataResult<PostDTO>>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}

