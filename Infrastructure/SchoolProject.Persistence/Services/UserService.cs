﻿using System;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services
{
    public class UserService : IUserService
    {
        IUserCommandRepository _userCommandRepository;
        IUserQueryRepository _userQueryRepository;

        public UserService(IUserQueryRepository userQueryRepository, IUserCommandRepository userCommandRepository)
        {
            _userQueryRepository = userQueryRepository;
            _userCommandRepository = userCommandRepository;
        }

        public async Task<UserDTO> AddAsync(AddUserDTO addUserDTO)
        {
            User user = await _userCommandRepository.AddAsync(new()
            { NickName = addUserDTO.NickName,
                Name = addUserDTO.Name,
                Surname = addUserDTO.Surname,
                Mail = addUserDTO.Mail,
                PhoneNumber = addUserDTO.PhoneNumber,
                Password = addUserDTO.password
            });
            await _userCommandRepository.SaveAsync();
            return new() { Id = Convert.ToString(user.Id), Mail = user.Mail, Name = user.Name, NickName = user.NickName, PhoneNumber = user.PhoneNumber, Surname = user.Surname  , Password = user.Password};
        }

        public async Task<UserDTO> DeleteAsync(string id)
        {
            User user = await _userCommandRepository.RemoveAsync(id);
            await _userCommandRepository.SaveAsync();
            return new() { Id = Convert.ToString(user.Id), Mail = user.Mail, Name = user.Name, Surname = user.Surname, NickName = user.NickName, PhoneNumber = user.PhoneNumber, Password = user.Password };
        }

        public async Task<(List<GetAllUsersDTO>, int totalCount)> GetAllAsync(int page, int size)
            => (await _userQueryRepository.GetAll().Where(u => u.IsActive == true).Skip(size * page).Take(size).Select(u => new GetAllUsersDTO
            {
                Id = Convert.ToString(u.Id),
                Mail = u.Mail,
                Name = u.Name,
                Surname = u.Surname,
                NickName = u.NickName,
                PhoneNumber = u.PhoneNumber
            }).ToListAsync(), await _userQueryRepository.GetAll().CountAsync());      

        public async Task<GetByIdUserDTO> GetByIdAsync(string id)
        {
            User user = await _userQueryRepository.GetByIdAsync(id);
            return new()
            {
                Id = Convert.ToString(user.Id),
                Mail = user.Mail,
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                PhoneNumber = user.PhoneNumber
            };
        }

        public async Task<UserDTO> UpdateAsync(UpdateUserDTO updateUserDTO)
        {
            User user = await _userQueryRepository.GetByIdAsync(updateUserDTO.Id);
            user.Name = updateUserDTO.Name == "string" ? user.Name : updateUserDTO.Name;
            user.Surname = updateUserDTO.Surname == "string" ? user.Surname : updateUserDTO.Surname;
            user.NickName = updateUserDTO.NickName == "string" ? user.NickName : updateUserDTO.NickName;
            user.Mail = updateUserDTO.Mail == "string" ? user.Mail : updateUserDTO.Mail;
            user.IsActive = updateUserDTO.IsActive == default ? user.IsActive : updateUserDTO.IsActive;
            user.IsProfilePrivate = updateUserDTO.IsProfilePrivate == default ? user.IsProfilePrivate : updateUserDTO.IsProfilePrivate;
            user.Password = updateUserDTO.Password == "string" ? user.Password : updateUserDTO.Password;
            await _userCommandRepository.SaveAsync();
            return new()
            {
                Id = Convert.ToString(user.Id),
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                Mail = user.Mail,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password
            };
        }
    }
}

