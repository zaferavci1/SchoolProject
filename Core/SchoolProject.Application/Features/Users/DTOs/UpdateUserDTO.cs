using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Users.DTOs
{
	public class UpdateUserDTO : IDTO
	{
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsProfilePrivate { get; set; }
    }
}

