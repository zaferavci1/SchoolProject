using System;
using MediatR;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Commands.Delete
{
	public class DeletePostCommandRequest : IRequest<IDataResult<PostDTO>>
    {
		public string Id { get; set; }
	}
}

