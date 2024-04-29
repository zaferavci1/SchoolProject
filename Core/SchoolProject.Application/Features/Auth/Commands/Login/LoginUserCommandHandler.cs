using System;
using System.Data;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Abstraction.Token;
using SchoolProject.Application.Features.Auth.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Auth.Commands.Login
{
    public class LoginUserCommandHandler  : IRequestHandler<LoginUserCommandRequest, IDataResult<LoginUserCommandResponse>>
	{
        readonly IUserService _userService;
        readonly ITokenHandler _tokenHandler;
        readonly IAuthService _authService;
        readonly IUserQueryRepository _userQueryRepository;
        private readonly IDataProtector userDataProtector;
        public LoginUserCommandHandler(IUserService userService, ITokenHandler tokenHandler, IAuthService authService, IDataProtectionProvider dataProtectionProvider, IUserQueryRepository userQueryRepository, IDataProtector userDataProtector)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
            _authService = authService;
            _userQueryRepository = userQueryRepository;
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
        }

        public async Task<IDataResult<LoginUserCommandResponse>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            
            (User user, Token token) data = await _authService.LoginAsync(request.UserNameOrMail, request.Password, 15);
            LoginUserCommandResponse loginUserCommandResponse = new();
            loginUserCommandResponse.UserDTO = data.user.Adapt<UserDTO>();
            loginUserCommandResponse.TokenDTO = data.token.Adapt<TokenDTO>();
            loginUserCommandResponse.UserDTO.Id = userDataProtector.Protect(data.user.Id.ToString());

            return new SuccessDataResult<LoginUserCommandResponse>("başarılı", loginUserCommandResponse);
        }
    }
}

