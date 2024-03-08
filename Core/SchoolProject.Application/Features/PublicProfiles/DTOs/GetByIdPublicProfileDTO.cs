using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.PublicProfiles.DTOs
{
	public class GetByIdPublicProfileDTO : IDTO
	{
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public List<GetAllUsersDTO> Followers { get; set; }
        public List<GetAllUsersDTO> Follows { get; set; }
        public List<GetAllPostsDTO> Posts { get; set; }
    }
}

