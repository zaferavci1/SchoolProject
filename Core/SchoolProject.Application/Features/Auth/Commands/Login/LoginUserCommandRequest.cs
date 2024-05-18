using System;
using MediatR;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Auth.Commands.Login
{
	public class LoginUserCommandRequest :IRequest<IDataResult<LoginUserCommandResponse>>
	{
		public string UserNameOrMail { get; set; }
		public string Password { get; set; }
	}
}

