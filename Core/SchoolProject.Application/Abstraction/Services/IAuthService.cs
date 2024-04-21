using System;
using SchoolProject.Application.Abstraction.Services.Authentications;
using SchoolProject.Application.Features.Users.Commands.Add;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Services
{
	public interface IAuthService : IInternalAuthentication
	{
        Task<UserDTO> CreateAsync(AddUserCommandRequest model);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    }
}

