using MediatR;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Notifications.Commands.Add.Comment
{
	public class AddCommentNotificationCommandRequest : IRequest<IDataResult<NotificationDTO>>
    {

        public string UserId { get; set; }
        public string CommenterUserId { get; set; }
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public string Message { get; set; }
    }
}

