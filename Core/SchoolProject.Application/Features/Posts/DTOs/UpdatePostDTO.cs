using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Posts.DTOs
{
	public class UpdatePostDTO : IDTO
	{
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}

