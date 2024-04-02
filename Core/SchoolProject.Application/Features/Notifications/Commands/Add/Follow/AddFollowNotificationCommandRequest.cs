using System;
using MediatR;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Commands.Add.Follow
{
	public class AddFollowNotificationCommandRequest : IRequest<IDataResult<NotificationDTO>>
    {
        public string UserId { get; set; }
        public string FollowerUserId { get; set; }
        public string Message { get; set; }
    }
}

