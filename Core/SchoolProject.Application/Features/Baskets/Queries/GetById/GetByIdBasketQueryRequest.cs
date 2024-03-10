using System;
using MediatR;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Queries.GetById
{
    public class GetByIdBasketQueryRequest : IRequest<IDataResult<GetByIdBasketDTO>>
	{
		public string Id { get; set; }
		
	}
}

