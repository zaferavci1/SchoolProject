using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Abstraction.Services.Authentications;
using SchoolProject.Application.Abstraction.Token;
using SchoolProject.Application.Exceptions;
using SchoolProject.Application.Features.Users.Commands.Add;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services
{
	public class AuthService : IAuthService
	{
        readonly IConfiguration _configuration;
        readonly IUserService _userService;
        readonly IUserQueryRepository _userQueryRepository;
        readonly ITokenHandler _tokenHandler;

        public AuthService(IConfiguration configuration, IUserService userService, ITokenHandler tokenHandler, IUserQueryRepository userQueryRepository)
        {
            _configuration = configuration;
            _userService = userService;
            _tokenHandler = tokenHandler;
            _userQueryRepository = userQueryRepository;
        }

        async Task<UserDTO> IAuthService.CreateAsync(AddUserCommandRequest model)
        {
            UserDTO userDto = await _userService.AddAsync(new()
            {
                NickName = model.NickName,
                Name = model.Name,
                Surname = model.Surname,
                Mail = model.Mail,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password
            });

            return userDto;
        }

        async Task<(User,Token)> IInternalAuthentication.LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            User? user = await _userQueryRepository.Table.FirstOrDefaultAsync(u=>u.NickName == usernameOrEmail || u.Mail == usernameOrEmail);
            if (user is null)
            {
                throw new CustomException<UserDTO>("User Doesnt Not Found");
            }
            bool result = user.Password == password;
            if (!result)
            {
                throw new CustomException<UserDTO>("Wrong Password Or Nickname");
            }
            Token? token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
            return (user,token);
            
        }

        Task<Token> IInternalAuthentication.RefreshTokenLoginAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }


        Task IAuthService.UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}

