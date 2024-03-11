using System;
using MediatR;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Queries.GetAll
{
	public class GetAllBasketsQueryResponse : IRequest<IDataResult<GetAllBasketsDTO>> , IDTO
	{
		public List<GetAllBasketsDTO> getAllBasketsDTOs { get; set; }
		public int TotalCount { get; set; }
	}
}

