using System;
namespace SchoolProject.Application.Features.Notifications.DTOs
{
	public class AddCommentNotificationDTO
    {
        public string UserId { get; set; }
        public string CommenterUserId { get; set; }
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public string Message { get; set; }

    }
}

