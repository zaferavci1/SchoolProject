using System;
using MediatR;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Features.Auth.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Auth.Commands.Login
{
	public class LoginUserCommandResponse : IRequest<IDataResult<TokenDTO>>, IDTO
    {

		public TokenDTO TokenDTO { get; set; }
		public UserDTO UserDTO { get; set; }
	}
}

