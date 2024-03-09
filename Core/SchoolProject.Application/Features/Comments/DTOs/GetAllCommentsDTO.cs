using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class GetAllCommentsDTO : IDTO
	{ 
        public int Id { get; set; } 
        public string Content { get; set; }
        public List<CommentDTO> ReplyComments { get; set; }
    }
}

