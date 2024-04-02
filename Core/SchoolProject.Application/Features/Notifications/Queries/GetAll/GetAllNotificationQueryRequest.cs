using System;
using MediatR;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Queries.GetAll
{
	public class GetAllNotificationQueryRequest : IRequest<IDataResult<GetAllNotificationQueryResponse>>
    {
		public int Page { get; set; }
		 public int Size { get; set; }
	}
}

