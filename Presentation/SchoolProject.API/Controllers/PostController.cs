﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Posts.Commands.Add;
using SchoolProject.Application.Features.Posts.Commands.Delete;
using SchoolProject.Application.Features.Posts.Commands.Like;
using SchoolProject.Application.Features.Posts.Commands.UnLike;
using SchoolProject.Application.Features.Posts.Commands.Update;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Posts.Queries.GetAll;
using SchoolProject.Application.Features.Posts.Queries.GetById;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostCommandRequest addPostommandRequest)
        {
            IDataResult<PostDTO> response = await _mediator.Send(addPostommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePostCommandRequest updatePostCommandRequest)
        {
            IDataResult<PostDTO> response = await _mediator.Send(updatePostCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Delete( DeletePostCommandRequest deletePostCommandRequest)
        {
            IDataResult<PostDTO> response = await _mediator.Send(deletePostCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPostQueryRequest getByIdPostQueryRequest)
        {
            IDataResult<GetByIdPostDTO> response = await _mediator.Send(getByIdPostQueryRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Like(LikePostCommandRequest likePostCommandRequest)
        {
            IDataResult<PostDTO> response = await _mediator.Send(likePostCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UnLike(UnLikePostCommandRequest unLikePostCommandRequest)
        {
            IDataResult<PostDTO> response = await _mediator.Send(unLikePostCommandRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPostQueryRequest getAllPostQueryRequest)
        {
            IDataResult<GetAllPostQueryResponse> response = await _mediator.Send(getAllPostQueryRequest);
            return Ok(response);
        }
    }
}

