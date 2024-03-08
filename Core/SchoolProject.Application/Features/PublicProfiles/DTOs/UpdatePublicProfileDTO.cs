using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.PublicProfiles.DTOs
{
	public class UpdatePublicProfileDTO : IDTO
	{
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

