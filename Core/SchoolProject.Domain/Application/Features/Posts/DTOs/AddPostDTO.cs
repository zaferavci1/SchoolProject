using System;
using SchoolProject.Domain.Application.Abstraction.DTO;

namespace SchoolProject.Domain.Application.Features.Posts.DTOs
{
	public class AddPostDTO : IDTO
	{
		public string Title { get; set; }
        public string Content { get; set; }
    }
}

