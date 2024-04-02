using System;
namespace SchoolProject.Application.Features.Notifications.DTOs
{
	public class AddFollowNotificationDTO
    {
        public string UserId { get; set; }
        public string FollowerUserId { get; set; }
        public string Message { get; set; }

    }
}

