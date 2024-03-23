using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Baskets.DTOs
{
	public class BasketDTO :IDTO
	{
		public string Id { get; set; }
		public string BasketName { get; set; }
		public int LikeCount { get; set; }
	}
}

