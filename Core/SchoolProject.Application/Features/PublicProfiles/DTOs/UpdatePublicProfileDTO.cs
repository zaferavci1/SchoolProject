using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.PublicProfiles.DTOs
{
	public class UpdatePublicProfileDTO : IDTO
	{ 
        public int Id { get; set; } 
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

