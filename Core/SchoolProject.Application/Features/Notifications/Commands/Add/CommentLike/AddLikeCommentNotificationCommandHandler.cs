using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Notifications.Commands.Add.Comment;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Commands.Add.CommentLike
{
    public class AddLikeCommentNotificationCommandHandler : IRequestHandler<AddLikeCommentNotificationCommandRequest, IDataResult<NotificationDTO>>
    {
        INotificationService _notificationService;

        public AddLikeCommentNotificationCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IDataResult<NotificationDTO>> Handle(AddLikeCommentNotificationCommandRequest request, CancellationToken cancellationToken)
        {
            NotificationDTO notificationDTO = await _notificationService.AddAsync(request.Adapt<AddLikeCommentNotificationDTO>());
            var data = new SuccessDataResult<NotificationDTO>(notificationDTO.Message, notificationDTO);
            return data;    
        }
    }
}

