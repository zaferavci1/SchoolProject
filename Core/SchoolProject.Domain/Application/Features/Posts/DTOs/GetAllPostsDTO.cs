using System;
using SchoolProject.Domain.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Domain.Application.Features.Posts.DTOs
{
	public class GetAllPostsDTO : IDTO
	{
		public int Id { get; set; }
		public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

