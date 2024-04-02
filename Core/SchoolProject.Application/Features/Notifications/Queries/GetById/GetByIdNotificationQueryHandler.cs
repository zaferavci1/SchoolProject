using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;

using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Queries.GetById
{
	public class GetByIdNotificationQueryHandler : IRequestHandler<GetByIdNotificationQueryRequest, IDataResult<GetByIdNotificationDTO>>
    {
        private INotificationService _notificationService;
    public GetByIdNotificationQueryHandler(INotificationService notificationService)
    {
            _notificationService = notificationService;
    }

    public async Task<IDataResult<GetByIdNotificationDTO>> Handle(GetByIdNotificationQueryRequest request, CancellationToken cancellationToken)
    {
        GetByIdNotificationDTO notificationDTO = await _notificationService.GetByIdAsync(request.Id);
        return new SuccessDataResult<GetByIdNotificationDTO>("Bildirim Getirildi", notificationDTO);
    }
}
}

