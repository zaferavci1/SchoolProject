using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.Auth.DTOs
{
	public class TokenDTO : IDTO
	{
		public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}

