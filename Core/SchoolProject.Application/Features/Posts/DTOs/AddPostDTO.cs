using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Posts.DTOs
{
	public class AddPostDTO : IDTO
	{
		public string Title { get; set; }
        public string Content { get; set; }
    }
}

