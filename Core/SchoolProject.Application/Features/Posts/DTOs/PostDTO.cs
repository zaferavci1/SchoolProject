using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Posts.DTOs
{
	public class PostDTO : IDTO
	{
		public string Title { get; set; }
        public string Content { get; set; }
    }
}

