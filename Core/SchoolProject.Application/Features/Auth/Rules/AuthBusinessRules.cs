using System;
using SchoolProject.Application.Abstraction.Repository.Users;

namespace SchoolProject.Application.Features.Auth.Rules
{
	public class AuthBusinessRules
	{
		readonly IUserQueryRepository _userQueryRepository;
        public AuthBusinessRules(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }
    }
}

