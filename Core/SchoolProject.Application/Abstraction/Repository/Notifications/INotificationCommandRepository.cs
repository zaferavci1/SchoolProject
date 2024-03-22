using System;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository.Notifications
{
	public interface INotificationCommandRepository : ICommandRepository<Notification>
    {
	}
}

