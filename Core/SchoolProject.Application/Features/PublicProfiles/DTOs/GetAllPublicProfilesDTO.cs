using System;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.PublicProfiles.DTOs
{
	public class GetAllPublicProfilesDTO : IDTO
	{ 
        public int Id { get; set; } 
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public List<User> Followers { get; set; }
        public List<User> Follows { get; set; }
        public List<GetAllPostsDTO> Posts { get; set; }
        public bool IsActive { get; set; }
    }
}

