using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class UpdateCommentDTO : IDTO
	{
        public string Content { get; set; }
    }
}

