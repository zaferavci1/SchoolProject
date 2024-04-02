using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Notifications.DTOs
{
	public class GetAllNotificationsDTO : IDTO
    { 
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}

