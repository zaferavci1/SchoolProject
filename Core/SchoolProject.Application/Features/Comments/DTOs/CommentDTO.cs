using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class CommentDTO : IDTO
	{

        public string Content { get; set; }
    }
}

