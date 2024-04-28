using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Comments.Commands.Add;
using SchoolProject.Application.Features.Comments.Commands.Delete;
using SchoolProject.Application.Features.Comments.Commands.Like;
using SchoolProject.Application.Features.Comments.Commands.Unlike;
using SchoolProject.Application.Features.Comments.Commands.Update;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Application.Features.Comments.Queries.GetAll;
using SchoolProject.Application.Features.Comments.Queries.GetById;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "User")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCommentCommandRequest addCommentCommandRequest)
        {
            IDataResult<CommentDTO> response = await _mediator.Send(addCommentCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCommentCommandRequest updateCommentCommandRequest)
        {
            IDataResult<CommentDTO> response = await _mediator.Send(updateCommentCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Delete(DeleteCommentCommandRequest deleteCommentCommandRequest)
        {
            IDataResult<CommentDTO> response = await _mediator.Send(deleteCommentCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCommentQueryRequest getByIdCommentQueryRequest)
        {
            IDataResult<GetByIdCommentDTO> response = await _mediator.Send(getByIdCommentQueryRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Like(LikeCommentCommandRequest likeCommentCommandRequest)
        {
            IDataResult<CommentDTO> response = await _mediator.Send(likeCommentCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UnLike(UnLikeCommentCommandRequest unLikeCommentCommandRequest)
        {
            IDataResult<CommentDTO> response = await _mediator.Send(unLikeCommentCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCommentQueryRequest getAllCommentQueryRequest)
        {
            IDataResult<GetAllCommentQueryResponse> response = await _mediator.Send(getAllCommentQueryRequest);
            return Ok(response);
        }
    }
}

