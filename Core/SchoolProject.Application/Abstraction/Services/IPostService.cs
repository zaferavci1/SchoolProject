using System;
using SchoolProject.Application.Features.Posts.DTOs;

namespace SchoolProject.Application.Abstraction.Services
{
	public interface IPostService
	{
		Task<(List<GetAllPostsDTO>, int totalCount)> GetAllAsync(int page, int size);
		Task<GetByIdPostDTO> GetByIdAsync(int id);
		Task<PostDTO> AddAsync(AddPostDTO addPostDTO);
		Task<PostDTO> UpdateAsync(UpdatePostDTO updatePostDTO);
		Task<PostDTO> DeleteAsync(int id);
	}
}

