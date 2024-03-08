using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.PublicProfiles.DTOs
{
	public class GetAllPublicProfilesDTO : IDTO
	{
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public List<PublicProfile> Followers { get; set; }
        public List<PublicProfile> Follows { get; set; }
        public List<GetAllPostsDTO> Posts { get; set; }
        public bool IsActive { get; set; }
    }
}

