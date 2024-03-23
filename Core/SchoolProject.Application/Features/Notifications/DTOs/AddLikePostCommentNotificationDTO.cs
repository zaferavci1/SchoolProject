using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Notifications.DTOs
{
	public class AddLikePostCommentNotificationDTO : IDTO
	{
        public string UserId { get; set; }
        public string LikerUserId { get; set; }
        public string PostId { get; set; }
    }
}

