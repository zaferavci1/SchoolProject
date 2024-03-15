using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Users.Commands.Add;
using SchoolProject.Application.Features.Users.Commands.Delete;
using SchoolProject.Application.Features.Users.Commands.Follow;
using SchoolProject.Application.Features.Users.Commands.Update;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Queries.GetAll;
using SchoolProject.Application.Features.Users.Queries.GetById;
using SchoolProject.Application.Utilities.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserCommandRequest addUserCommandRequest)
        {
            IDataResult<UserDTO> response = await _mediator.Send(addUserCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommandRequest updateUserCommandRequest)
        {
            IDataResult<UserDTO> response = await _mediator.Send(updateUserCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommandRequest deleteUserCommandRequest)
        {
            IDataResult<UserDTO> response = await _mediator.Send(deleteUserCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserQueryRequest getByIdUserQueryRequest)
        {
            IDataResult<GetByIdUserDTO> response = await _mediator.Send(getByIdUserQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserQueryRequest getAllUserQueryRequest)
        {
            IDataResult<GetAllUserQueryResponse> response = await _mediator.Send(getAllUserQueryRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> FollowSomeone(FollowUserCommandRequest followUserCommandRequest)
        {
            IDataResult<UserDTO> response = await _mediator.Send(followUserCommandRequest);
            return Ok(response);
        }
    }
}

