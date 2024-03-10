﻿using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Users.DTOs
{
	public class UpdateUserDTO : IDTO
	{ 
        public string Id { get; set; } 
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsProfilePrivate { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
    }
}
