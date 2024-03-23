using System;
using MediatR;
using SchoolProject.Application.Features.Users.Queries.GetAll;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetByIdUsersPosts
{
	public class GetByIdUsersPostsQueryRequest : IRequest<IDataResult<GetByIdUsersPostsQueryResponse>>
    {
		public string userId { get; set; }
	}
}

