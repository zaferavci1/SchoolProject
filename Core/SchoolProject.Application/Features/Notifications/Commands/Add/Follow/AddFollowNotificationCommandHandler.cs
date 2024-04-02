using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Notifications.Commands.Add.CommentLike;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Commands.Add.Follow
{
	public class AddFollowNotificationCommandHandler : IRequestHandler<AddFollowNotificationCommandRequest, IDataResult<NotificationDTO>>
    {
        INotificationService _notificationService;

        public AddFollowNotificationCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IDataResult<NotificationDTO>> Handle(AddFollowNotificationCommandRequest request, CancellationToken cancellationToken)
        {
            NotificationDTO notificationDTO = await _notificationService.AddAsync(new AddFollowNotificationDTO()
            {
                UserId = request.UserId,
                FollowerUserId = request.FollowerUserId,
                Message = request.Message
            });
            var data = new SuccessDataResult<NotificationDTO>(notificationDTO.Message, notificationDTO);
            return data;
        }
    }
}

