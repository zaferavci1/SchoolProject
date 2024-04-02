using System;
using MediatR;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Queries.GetById
{
	public class GetByIdNotificationQueryRequest : IRequest<IDataResult<GetByIdNotificationDTO>>
    {
        public string Id { get; set; }
    }
}

