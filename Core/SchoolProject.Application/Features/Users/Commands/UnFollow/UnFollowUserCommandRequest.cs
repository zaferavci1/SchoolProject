using System;
using MediatR;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.UnFollow
{
	public class UnFollowUserCommandRequest : IRequest<IDataResult<UserDTO>>
	{
        public string user1 { get; set; }
        public string user2 { get; set; }
    }
}
