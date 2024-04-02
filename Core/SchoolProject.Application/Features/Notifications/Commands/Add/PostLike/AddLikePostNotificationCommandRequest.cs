using System;
using MediatR;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Commands.Add.PostLike
{
	public class AddLikePostNotificationCommandRequest : IRequest<IDataResult<NotificationDTO>>
    {
        public string UserId { get; set; }
        public string LikerUserId { get; set; }
        public string PostId { get; set; }
        public string Message { get; set; }
    }
}

