using System;
using SchoolProject.Application.Features.Comments.DTOs;

namespace SchoolProject.Application.Abstraction.Services
{
	public interface ICommentService
	{

        Task<(List<GetAllCommentsDTO>, int totalCount)> GetAllAsync(int page, int size);
        Task<GetByIdCommentDTO> GetByIdAsync(string id);
        Task<CommentDTO> AddAsync(AddCommentDTO addCommentDTO);
        Task<CommentDTO> UpdateAsync(UpdateCommentDTO updateCommentDTO);
        Task<CommentDTO> DeleteAsync(string id);
        Task<CommentDTO> LikeAsync(string id);
    }
}

