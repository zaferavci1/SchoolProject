using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Posts.DTOs
{
	public class GetByIdPostDTO : IDTO
	{
        public string UserId { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}

