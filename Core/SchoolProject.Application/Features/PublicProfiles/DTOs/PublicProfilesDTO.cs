using System;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.PublicProfiles.DTOs
{
	public class PublicProfilesDTO : IDTO
	{
        public string? Id { get; set; }
        public string? NickName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
     
        public byte ProfilePictureId { get; set; }
    }
}

