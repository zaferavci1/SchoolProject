using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class UpdateCommentDTO : IDTO
	{
        public string Id { get; set; } 
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}

