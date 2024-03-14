using System;
using SchoolProject.Application.Features.Users.DTOs;

namespace SchoolProject.Application.Abstraction.Services
{
	public interface IUserService
	{
        Task<(List<GetAllUsersDTO>, int totalCount)> GetAllAsync(int page, int size);
        Task<GetByIdUserDTO> GetByIdAsync(string id);
        Task<UserDTO> AddAsync(AddUserDTO addUserDTO);
        Task<UserDTO> UpdateAsync(UpdateUserDTO updateUserDTO);
        Task<UserDTO> DeleteAsync(string id);
        Task<UserDTO> FollowSomeoneAsync(string id1, string id2);

    }
}

