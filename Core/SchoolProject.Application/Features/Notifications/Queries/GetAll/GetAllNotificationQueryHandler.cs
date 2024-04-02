using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Queries.GetAll
{
    public class GetAllNotificationQueryHandler : IRequestHandler<GetAllNotificationQueryRequest, IDataResult<GetAllNotificationQueryResponse>>
	{
		INotificationService _notificationService;
        public GetAllNotificationQueryHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IDataResult<GetAllNotificationQueryResponse>> Handle(GetAllNotificationQueryRequest request, CancellationToken cancellationToken)
        {
            (List<GetAllNotificationsDTO> notifications, int TotalCount) data = await _notificationService.GetAllAsync(request.Page,request.Size);
            return new SuccessDataResult<GetAllNotificationQueryResponse>("Bildirimler listelendi", new() { getAllNotificaitonsDTOs = data.notifications, TotalCount = data.TotalCount}); 

        }
    }
}

