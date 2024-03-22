using System;
using MediatR;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Queries.GetByIdUsersComments
{
    public class GetByIdUsersCommentsQueryRequest : IRequest<IDataResult<GetByIdUsersCommentsQueryResponse>>
    {
		public string userId { get; set; }
}
}

