using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.PublicProfiles.DTOs
{
	public class AddPublicProfilesDTO : IDTO
	{
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
    }
}

