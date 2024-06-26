﻿using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.Posts.DTOs
{
	public class AddPostDTO : IDTO
	{
		public string UserId { get; set; }
		public string Title { get; set; }
        public string Content { get; set; }
    }
}

