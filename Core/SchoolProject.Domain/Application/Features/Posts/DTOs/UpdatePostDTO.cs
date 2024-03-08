using System;
using SchoolProject.Domain.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Domain.Application.Features.Posts.DTOs
{
	public class UpdatePostDTO : IDTO
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
        public bool IsActive { get; set; }
    }
}

