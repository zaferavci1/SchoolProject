using System;
using SchoolProject.Application.Abstraction.Repository.Notifications;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Notificationss
{
	public class NotificationCommandRepository : CommandRepository<Notification> , INotificationCommandRepository
    {

        public NotificationCommandRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
        {
        }
    }
}

