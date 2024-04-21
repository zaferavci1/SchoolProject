using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Features.Posts.Commands.Add;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Commands.Add.Comment
{
	public class AddCommentNotificationCommandHandler : IRequestHandler<AddCommentNotificationCommandRequest, IDataResult<NotificationDTO>>
    {
        INotificationService _notificationService;

        public AddCommentNotificationCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IDataResult<NotificationDTO>> Handle(AddCommentNotificationCommandRequest request, CancellationToken cancellationToken)
        {
            NotificationDTO notificationDTO = await _notificationService.AddAsync(request.Adapt<AddCommentNotificationDTO>());
            var data = new SuccessDataResult<NotificationDTO>(notificationDTO.Message, notificationDTO);
            return data;
        }
    }
}

