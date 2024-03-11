using System;
using MediatR;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Delete
{
	public class DeleteUserCommandRequest : IRequest<IDataResult<UserDTO>>
	{
		public string Id { get; set; }
	}
}

