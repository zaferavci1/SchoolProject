using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class UpdateCommentDTO : IDTO
	{

        public int Id { get; set; } 
        public string Content { get; set; }
    }
}

