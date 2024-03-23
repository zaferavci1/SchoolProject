using System;
using SchoolProject.Application.Abstraction.Repository.Notifications;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Notifications.DTOs;

namespace SchoolProject.Persistence.Services
{
	public class NotificationService : INotificationService
	{
        private readonly INotificationQueryRepository _notificationQueryRepository;
        private readonly INotificationCommandRepository _notificationCommandRepository;
        public NotificationService(INotificationCommandRepository notificationCommandRepository, INotificationQueryRepository notificationQueryRepository)
        {
            _notificationCommandRepository = notificationCommandRepository;
            _notificationQueryRepository = notificationQueryRepository;
        }

        public Task<NotificationDTO> AddAsync(AddFollowNotificationDTO addFollowNotificationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> AddAsync(AddLikeCommentNotificationDTO addLikeCommentNotificationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationDTO> AddAsync(AddLikePostCommentNotificationDTO addLikePostCommentNotificationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(List<GetAllNotificationsDTO>, int totalCount)> GetAllAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdNotificationDTO> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

