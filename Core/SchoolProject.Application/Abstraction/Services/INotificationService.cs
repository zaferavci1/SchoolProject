using System;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Users.DTOs;

namespace SchoolProject.Application.Abstraction.Services
{
	public interface INotificationService
    {
        Task<(List<GetAllNotificationsDTO>, int totalCount)> GetAllAsync(int page, int size);
        Task<GetByIdNotificationDTO> GetByIdAsync(string id);
        Task<NotificationDTO> AddAsync(AddFollowNotificationDTO addFollowNotificationDTO);
        Task<NotificationDTO> AddAsync(AddCommentNotificationDTO addFollowNotificationDTO);
        Task<NotificationDTO> AddAsync(AddLikeCommentNotificationDTO addLikeCommentNotificationDTO);
        Task<NotificationDTO> AddAsync(AddLikePostNotificationDTO addLikePostCommentNotificationDTO);
    }
}
