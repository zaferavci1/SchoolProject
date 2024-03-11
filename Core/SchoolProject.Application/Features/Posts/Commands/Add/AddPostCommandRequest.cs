using System;
using MediatR;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Add
{
	public class AddPostCommandRequest : IRequest<IDataResult<PostDTO>>
	{
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

