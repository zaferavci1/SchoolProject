using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class GetByIdCommentDTO : IDTO
	{
        public int Id { get; set; }
        public string Content { get; set; }
    }
}

