using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Notifications.Commands.Add.Comment;
using SchoolProject.Application.Features.Notifications.Commands.Add.CommentLike;
using SchoolProject.Application.Features.Notifications.Commands.Add.Follow;
using SchoolProject.Application.Features.Notifications.Commands.Add.PostLike;
using SchoolProject.Application.Features.Notifications.DTOs;
using SchoolProject.Application.Features.Notifications.Queries.GetAll;
using SchoolProject.Application.Features.Notifications.Queries.GetById;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddFollowNotification(AddFollowNotificationCommandRequest addFollowNotificationCommandRequest)
        {
            IDataResult<NotificationDTO> response = await _mediator.Send(addFollowNotificationCommandRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentNotification(AddCommentNotificationCommandRequest addCommentNotificationCommandRequest)
        {
            IDataResult<NotificationDTO> response = await _mediator.Send(addCommentNotificationCommandRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddLikeCommentNotification(AddLikeCommentNotificationCommandRequest addLikeCommentNotificationCommandRequest)
        {
            IDataResult<NotificationDTO> response = await _mediator.Send(addLikeCommentNotificationCommandRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddLikePostNotification(AddLikePostNotificationCommandRequest addLikePostNotificationCommandRequest)
        {
            IDataResult<NotificationDTO> response = await _mediator.Send(addLikePostNotificationCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllNotificationQueryRequest getAllNotificationQueryRequest)
        {
            IDataResult<GetAllNotificationQueryResponse> response = await _mediator.Send(getAllNotificationQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdNotificationQueryRequest getByIdNotificationQueryRequest)
        {
            IDataResult<GetByIdNotificationDTO> response = await _mediator.Send(getByIdNotificationQueryRequest);
            return Ok(response);
        }
    }
}

