using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.Baskets.DTOs;

namespace SchoolProject.Application.Features.Baskets.Queries.GetAll
{
	public class GetAllBasketsQueryResponse : IDTO
	{
		public List<GetAllBasketsDTO> getAllBasketsDTOs { get; set; }
		public int TotalCount { get; set; }
	}
}

