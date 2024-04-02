using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Notifications.DTOs
{
	public class GetByIdNotificationDTO : IDTO
	{
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public string Message { get; set; } 
	}
}

