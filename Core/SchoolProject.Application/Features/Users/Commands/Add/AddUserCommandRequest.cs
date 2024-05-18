using System;
using MediatR;
using SchoolProject.Application.Features.Auth.Commands.Login;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Add
{
	public class AddUserCommandRequest : IRequest<IDataResult<LoginUserCommandResponse>>
	{
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}

