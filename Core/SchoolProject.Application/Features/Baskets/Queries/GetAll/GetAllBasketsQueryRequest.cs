using System;
using MediatR;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Queries.GetAll
{
	public class GetAllBasketsQueryRequest : IRequest<IDataResult<GetAllBasketsQueryResponse>>
    {
		public int Page { get; set; }
		public int Size { get; set; }
	}
}

