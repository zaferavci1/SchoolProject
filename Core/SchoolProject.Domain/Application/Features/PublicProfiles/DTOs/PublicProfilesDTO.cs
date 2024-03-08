﻿using System;
using SchoolProject.Domain.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Domain.Application.Features.PublicProfiles.DTOs
{
	public class PublicProfilesDTO : IDTO
	{
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public List<PublicProfile> Posts { get; set; }
    }
}
