using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Posts.Commands.Add;
using SchoolProject.Application.Features.Posts.Commands.Delete;
using SchoolProject.Application.Features.Posts.Commands.Update;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Application.Features.Posts.Queries.GetAll;
using SchoolProject.Application.Features.Posts.Queries.GetById;
using SchoolProject.Application.Utilities.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeletePostCommandRequest deletePostCommandRequest)
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPostQueryRequest getAllPostQueryRequest)
        {
            IDataResult<GetAllPostQueryResponse> response = await _mediator.Send(getAllPostQueryRequest);
            return Ok(response);
        }
    }
}

