using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Posts.DTOs
{
	public class PostDTO : IDTO
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

