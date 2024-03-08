using System;
using SchoolProject.Domain.Application.Abstraction.DTO;

namespace SchoolProject.Domain.Application.Features.Posts.DTOs
{
	public class PostDTO : IDTO
	{
		public int Id { get; set; }
		public string Title { get; set; }
        public string Content { get; set; }
    }
}

