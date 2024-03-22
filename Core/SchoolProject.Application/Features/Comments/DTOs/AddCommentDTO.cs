using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class AddCommentDTO : IDTO
    {
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string Content { get; set; }
    }
}

