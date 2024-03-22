using System;
using SchoolProject.Application.Abstraction.Repository.Notifications;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Notificationss
{
    public class NotificationQueryRepository : QueryRepository<Notification> , INotificationQueryRepository
	{
        public NotificationQueryRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
        {
        }
    }
}

