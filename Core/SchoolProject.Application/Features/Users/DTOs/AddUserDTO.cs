﻿using System;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Users.DTOs
{
	public class AddUserDTO : IDTO
	{
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}

