using System;
namespace SchoolProject.Application.Features.Notifications.DTOs
{
	public class AddLikeCommentNotificationDTO
    {
        public string UserId { get; set; }
        public string LikerUserId { get; set; }
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public string Message { get; set; }
    }
}

