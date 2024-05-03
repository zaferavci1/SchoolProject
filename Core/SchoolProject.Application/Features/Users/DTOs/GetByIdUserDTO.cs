using System;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.PublicProfiles.DTOs;

namespace SchoolProject.Application.Features.Users.DTOs
{
	public class GetByIdUserDTO : IDTO
	{ 
        public string Id { get; set; } 
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        
        public byte ProfilePictureId { get; set; }
        public List<PublicProfilesDTO> Followers { get; set; }
        public List<PublicProfilesDTO> Follows { get; set; }
        public List<GetAllPostsDTO> Posts { get; set; }
        public List<GetAllCommentsDTO> Comments { get; set; }
    }
}

