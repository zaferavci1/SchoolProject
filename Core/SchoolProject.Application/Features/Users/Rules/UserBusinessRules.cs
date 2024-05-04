using System;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.DataProtection;
using SchoolProject.Application.Exceptions;
using SchoolProject.Application.Features.Users.DTOs;

namespace SchoolProject.Application.Features.Users.Rules
{
	public class UserBusinessRules
	{
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IDataProtector userDataProtector;
        public UserBusinessRules(IUserQueryRepository userQueryRepository , IDataProtectionProvider dataProtectionProvider)
        {
            _userQueryRepository = userQueryRepository;
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
        }
        public async Task IsUserExistAsync(string id)
        {
            User? user = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(id));
            if (user == null) throw new CustomException<UserDTO>("User Not Found");
        }
        public async Task IsUserActiveAsync(string id)
        {
            User? user = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(id));
            if (!user.IsActive) throw new CustomException<UserDTO>("User Not Active");
        }
        public async Task IsEmailExistsAsync(string email)
        {
            User? user =await _userQueryRepository.Table.FirstOrDefaultAsync(u=>u.Mail == email);
            if (user != null) throw new CustomException<UserDTO>("Email Exists");
        }
        public async Task IsNicNamekExistsAsync(string nickName)
        {
            User? user = await _userQueryRepository.Table.FirstOrDefaultAsync(u => u.NickName == nickName);
            if (user != null) throw new CustomException<UserDTO>("NickName Exists");
        }
        public async Task IsPhoneNumberExistAsync(string phoneNumber)
        {
            User? user = await _userQueryRepository.Table.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user != null) throw new CustomException<UserDTO>("PhoneNumber Exists");
        }
        public async Task IsOldPasswordCorrect(string userId, string password)
        {           
            User? user = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(userId));

            if (user.Password != password) throw new CustomException<UserDTO>("Old Password Is Not Correct");
        }
        public async Task UserAllReadyFollowedAsync(string firstUser, string secondUser)
        {
            bool check = await _userQueryRepository.Table.Include(u => u.Followees).AnyAsync(u => u.Followees.Any(f => f.FolloweeId == Guid.Parse(userDataProtector.Unprotect(firstUser)) && f.FollowerId == Guid.Parse(userDataProtector.Unprotect(secondUser))));
            if (check) throw new CustomException<UserDTO>("User Allready Followed");
        }
        public async Task IsUserFolloweeAsync(string firstUser, string secondUser)
        {
            bool check = await _userQueryRepository.Table.Include(u => u.Followees).AnyAsync(u => u.Followees.Any(f => f.FolloweeId == Guid.Parse(userDataProtector.Unprotect(firstUser)) && f.FollowerId == Guid.Parse(userDataProtector.Unprotect(secondUser))));
            if (!check) throw new CustomException<UserDTO>("User Allready Not Follow");
        }
        public async Task IsEmailsOwnerCorrectAsync(string mail, string userId)
        {
            User? user = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(userId));

            if (user.Mail != mail)
            {
                await IsEmailExistsAsync(mail);
            }
        }
        public async Task IsNicNamesOwnerCorrectAsync(string nickname, string userId)
        {
            User? user = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(userId));

            if (user.NickName != nickname)
            {
                await IsNicNamekExistsAsync(nickname);
            }
        }
        public async Task IsPhoneNumbersOwnerCorrectAsync(string phoneNumber, string userId)
        {
            User? user = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(userId));

            if (user.PhoneNumber != phoneNumber)
            {
                await IsPhoneNumberExistAsync(phoneNumber);
            }
        }

    }
}

