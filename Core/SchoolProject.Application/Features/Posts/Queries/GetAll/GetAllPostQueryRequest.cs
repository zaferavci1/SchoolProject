using System;
using MediatR;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Posts.Queries.GetAll
{
	public class GetAllPostQueryRequest : IRequest<IDataResult<GetAllPostQueryResponse>>
	{
        public int Page { get; set; }
        public int Size { get; set; }
    }
}

