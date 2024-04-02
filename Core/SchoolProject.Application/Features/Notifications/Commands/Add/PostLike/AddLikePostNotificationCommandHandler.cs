using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Notifications.Commands.Add.CommentLike;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Commands.Add.PostLike
{
	public class AddLikePostNotificationCommandHandler : IRequestHandler<AddLikePostNotificationCommandRequest, IDataResult<NotificationDTO>>
    {
        INotificationService _notificationService;

    public AddLikePostNotificationCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<IDataResult<NotificationDTO>> Handle(AddLikePostNotificationCommandRequest request, CancellationToken cancellationToken)
    {
        NotificationDTO notificationDTO = await _notificationService.AddAsync(new AddLikePostNotificationDTO()
        {
            UserId = request.UserId,
            LikerUserId = request.LikerUserId,
            PostId = request.PostId,
            Message = request.Message
        });
        var data = new SuccessDataResult<NotificationDTO>(notificationDTO.Message, notificationDTO);
        return data;
    }
}
}

