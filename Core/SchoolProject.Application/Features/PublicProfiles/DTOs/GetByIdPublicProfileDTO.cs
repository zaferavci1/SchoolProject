using System;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.PublicProfiles.DTOs
{
	public class GetByIdPublicProfileDTO : IDTO
	{ 
        public string? Id { get; set; } 
        public string? NickName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; } 
        public List<PublicProfilesDTO>? Followers { get; set; }
        public List<PublicProfilesDTO>? Follows { get; set; }
        public List<GetAllPostsDTO>? Posts { get; set; }
        public List<GetAllCommentsDTO>? Comments { get; set; }
    }
}

