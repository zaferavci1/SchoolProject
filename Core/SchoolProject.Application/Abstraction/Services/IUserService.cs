using System;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
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
        Task<(UserDTO, UserDTO)> FollowSomeoneAsync(string id1, string id2);
        Task<(List<GetAllPostsDTO>, int totalCount)> GetUsersPostsAsync(string id);
        Task<(List<GetAllCommentsDTO>, int totalCount)> GetUsersCommentsAsync(string id);

    }
}

