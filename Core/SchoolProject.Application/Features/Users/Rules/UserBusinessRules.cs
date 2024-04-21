using System;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.DataProtection;

namespace SchoolProject.Application.Features.Users.Rules
{
	public class UserBusinessRules
	{
		private readonly IUserService _userService;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IDataProtector userDataProtector;
        public UserBusinessRules(IUserService userService, IUserQueryRepository userQueryRepository , IDataProtectionProvider dataProtectionProvider)
        {
            _userService = userService;
            _userQueryRepository = userQueryRepository;
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
        }
        public async Task IsUserExist(string id)
        {
            User? user = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(id));
            if (user == null) throw new Exception("User Not Found");
        }
        public async Task IsUserActive(string id)
        {
            User? user = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(id));
            if (!user.IsActive) throw new Exception("User Not Active");
        }
        public async Task IsEmailExists(string email)
        {
            User? user =await _userQueryRepository.Table.FirstOrDefaultAsync(u=>u.Mail == email);
            if (user != null) throw new Exception("Email Exists");
        }
        public async Task IsNicNamekExists(string nickName)
        {
            User? user = await _userQueryRepository.Table.FirstOrDefaultAsync(u => u.NickName == nickName);
            if (user != null) throw new Exception("NickName Exists");
        }
        public async Task IsPhoneNumberExist(string phoneNumber)
        {
            User? user = await _userQueryRepository.Table.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user != null) throw new Exception("PhoneNumber Exists");
        }
        public async Task UserAllReadyFollowed(string firstUser, string secondUser)
        {
            bool check = await _userQueryRepository.Table.Include(u => u.Followees).AnyAsync(u => u.Followees.Any(f => f.FolloweeId == Guid.Parse(userDataProtector.Unprotect(firstUser)) && f.FollowerId == Guid.Parse(userDataProtector.Unprotect(secondUser))));
            if (check) throw new Exception("User Allready Followed");
        }
        public async Task IsUserFollowee(string firstUser, string secondUser)
        {
            bool check = await _userQueryRepository.Table.Include(u => u.Followees).AnyAsync(u => u.Followees.Any(f => f.FolloweeId == Guid.Parse(userDataProtector.Unprotect(firstUser)) && f.FollowerId == Guid.Parse(userDataProtector.Unprotect(secondUser))));
            if (!check) throw new Exception("User Allready Not Follow");
        }
        
    }
}

