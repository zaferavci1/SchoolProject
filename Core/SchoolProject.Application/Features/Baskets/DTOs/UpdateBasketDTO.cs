using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Baskets.DTOs
{ 
	public class UpdateBasketDTO : IDTO
	{
		public string Id { get; set; }
		public string BasketName { get; set; }
	}
}

