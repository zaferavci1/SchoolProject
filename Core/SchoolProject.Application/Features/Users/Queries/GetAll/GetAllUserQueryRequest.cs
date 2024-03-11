using System;
using MediatR;
using SchoolProject.Application.Features.Baskets.Queries.GetAll;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetAll
{
	public class GetAllUserQueryRequest : IRequest<IDataResult<GetAllUserQueryResponse>>
	{
        public int Page { get; set; }
        public int Size { get; set; }
    }
}

