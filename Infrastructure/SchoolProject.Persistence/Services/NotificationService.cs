using System;
using Microsoft.AspNetCore.DataProtection;
using SchoolProject.Application.Abstraction.Repository.Notifications;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services
{
	public class NotificationService : INotificationService
	{
        INotificationQueryRepository _notificationQueryRepository;
        INotificationCommandRepository _notificationCommandRepository;
        private readonly IDataProtector commentDataProtector;
        private readonly IDataProtector postDataProtector;
        private readonly IDataProtector userDataProtector;
        private readonly IDataProtector notificationDataProtector;
        IUserQueryRepository _userQueryRepository;
        
        public NotificationService(INotificationCommandRepository notificationCommandRepository, INotificationQueryRepository notificationQueryRepository, IDataProtectionProvider dataProtectionProvider, IUserQueryRepository userQueryRepository)
        {
            _notificationCommandRepository = notificationCommandRepository;
            _notificationQueryRepository = notificationQueryRepository;
            commentDataProtector = dataProtectionProvider.CreateProtector("Comments");
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
            postDataProtector = dataProtectionProvider.CreateProtector("Posts");
            notificationDataProtector = dataProtectionProvider.CreateProtector("Notifications");
            _userQueryRepository = userQueryRepository;
        }

        public async Task<NotificationDTO> AddAsync(AddCommentNotificationDTO addFollowNotificationDTO)
        {
            var commenterUser = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(addFollowNotificationDTO.CommenterUserId));

            Notification notification = new Notification()
            {
                FirstUserId = Guid.Parse(userDataProtector.Unprotect(addFollowNotificationDTO.UserId)),
                SecondUserId = Guid.Parse(userDataProtector.Unprotect(addFollowNotificationDTO.CommenterUserId)),
                PostId = Guid.Parse(postDataProtector.Unprotect(addFollowNotificationDTO.PostId)),
                CommentId = Guid.Parse(commentDataProtector.Unprotect(addFollowNotificationDTO.CommentId)),
                Message = $"{commenterUser.NickName} Adlı kullanıcı bir gönderinize yorum yaptı.",
                Type = NotificationType.CommentPost

            };
            await _notificationCommandRepository.AddAsync(notification);
            await _notificationCommandRepository.SaveAsync();
            return new() { Id = notificationDataProtector.Protect(notification.Id.ToString()), Message = notification.Message };
        }

        public async Task<NotificationDTO> AddAsync(AddLikeCommentNotificationDTO addLikeCommentNotificationDTO)
        {
            var commentLikerUser = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(addLikeCommentNotificationDTO.LikerUserId));

            Notification notification = new Notification()
            {
                FirstUserId = Guid.Parse(userDataProtector.Unprotect(addLikeCommentNotificationDTO.UserId)),
                SecondUserId = Guid.Parse(userDataProtector.Unprotect(addLikeCommentNotificationDTO.LikerUserId)),
                PostId = Guid.Parse(postDataProtector.Unprotect(addLikeCommentNotificationDTO.PostId)),
                CommentId = Guid.Parse(commentDataProtector.Unprotect(addLikeCommentNotificationDTO.CommentId)),
                Message = $"{commentLikerUser.NickName} Adlı kullanıcı bir yorumunuzu beğendi.",
                Type = NotificationType.LikeComment

            };
            await _notificationCommandRepository.AddAsync(notification);
            await _notificationCommandRepository.SaveAsync();
            return new() { Id = notificationDataProtector.Protect(notification.Id.ToString()), Message = notification.Message };
        }

        public async Task<NotificationDTO> AddAsync(AddLikePostNotificationDTO addLikePostNotificationDTO)
        {
            var postLikerUser = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(addLikePostNotificationDTO.LikerUserId));

            Notification notification = new Notification()
            {
                FirstUserId = Guid.Parse(userDataProtector.Unprotect(addLikePostNotificationDTO.UserId)),
                SecondUserId = Guid.Parse(userDataProtector.Unprotect(addLikePostNotificationDTO.LikerUserId)),
                PostId = Guid.Parse(postDataProtector.Unprotect(addLikePostNotificationDTO.PostId)),
                Message = $"{postLikerUser.NickName} Adlı kullanıcı bir gönderinizi beğendi.",
                Type = NotificationType.LikePost

            };
            await _notificationCommandRepository.AddAsync(notification);
            await _notificationCommandRepository.SaveAsync();
            return new() { Id = notificationDataProtector.Protect(notification.Id.ToString()), Message = notification.Message };
        }

        public async Task<NotificationDTO> AddAsync(AddFollowNotificationDTO addFollowNotificationDTO)
        {
            var followerUser = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(addFollowNotificationDTO.FollowerUserId));

            Notification notification = new Notification()
            {
                FirstUserId = Guid.Parse(userDataProtector.Unprotect(addFollowNotificationDTO.UserId)),
                SecondUserId = Guid.Parse(userDataProtector.Unprotect(addFollowNotificationDTO.FollowerUserId)),
                Message = $"{followerUser.NickName} Adlı kullanıcı sizi takip etti.",
                Type = NotificationType.Follow

            };
            await _notificationCommandRepository.AddAsync(notification);
            await _notificationCommandRepository.SaveAsync();
            return new() { Id = notificationDataProtector.Protect(notification.Id.ToString()), Message = notification.Message };
        }

        public async Task<(List<GetAllNotificationsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => new(_notificationQueryRepository.GetAll().Skip(size * page).Take(size).Select(n => new GetAllNotificationsDTO()
        {
            FirstUserId = userDataProtector.Protect(n.FirstUserId.ToString()),
            SecondUserId = userDataProtector.Protect(n.SecondUserId.ToString()),
            PostId = postDataProtector.Protect(n.PostId.ToString()),
            CommentId = commentDataProtector.Protect(n.CommentId.ToString()),
            Type = n.Type,
            Message = n.Message
        }).ToList() ?? new(), _notificationQueryRepository.GetAll().Count());

        public async Task<GetByIdNotificationDTO> GetByIdAsync(string id)
        {
            Notification notification = await _notificationQueryRepository.GetByIdAsync(notificationDataProtector.Unprotect(id));
            return new()
            {
                FirstUserId = userDataProtector.Protect(notification.FirstUserId.ToString()),
                SecondUserId = userDataProtector.Protect(notification.SecondUser.ToString()),
                PostId = postDataProtector.Protect(notification.Post.ToString()),
                CommentId = commentDataProtector.Protect(notification.Comment.ToString()),
                Message = notification.Message
            };
        }
    }
}

