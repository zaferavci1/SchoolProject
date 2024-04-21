using System;
using MediatR;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Queries.GetAll
{
	public class GetAllNotificationQueryResponse : IRequest<IDataResult<GetAllNotificationsDTO>> , IDTO
    {
		public List<GetAllNotificationsDTO> getAllNotificaitonsDTOs { get; set; }
		public int TotalCount { get; set; }
	}
}

