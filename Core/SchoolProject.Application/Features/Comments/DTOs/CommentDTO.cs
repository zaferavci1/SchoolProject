using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Comments.DTOs
{
	public class CommentDTO : IDTO
	{
        public string Id { get; set; }
        public int LikeCount { get; set; }
        public string Content { get; set; }
    }
}

