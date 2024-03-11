using System;
using MediatR;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Comments.Queries.GetAll
{
	public class GetAllCommentQueryRequest : IRequest<IDataResult<GetAllCommentQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}

