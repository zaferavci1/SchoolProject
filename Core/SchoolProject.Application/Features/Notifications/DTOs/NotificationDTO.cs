using System;
using SchoolProject.Application.Abstraction.DTO;

namespace SchoolProject.Application.Features.Notifications.DTOs
{
	public class NotificationDTO : IDTO
	{
        public string Id { get; set; }
        public string Message { get; set; }
    }
}

