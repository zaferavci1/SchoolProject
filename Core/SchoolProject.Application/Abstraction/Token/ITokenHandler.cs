using System;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Token
{
	public interface ITokenHandler
	{
        DTOs.Token CreateAccessToken(int second, User user);
        string CreateRefreshToken();
    }
}

