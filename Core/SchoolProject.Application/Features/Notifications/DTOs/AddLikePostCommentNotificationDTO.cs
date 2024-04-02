using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Notifications.DTOs
{
	public class AddLikePostNotificationDTO : IDTO
	{
        public string UserId { get; set; }
        public string LikerUserId { get; set; }
        public string PostId { get; set; }
        public string Message { get; set; }
    }
}

