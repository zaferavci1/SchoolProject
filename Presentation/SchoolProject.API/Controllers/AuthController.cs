using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Auth.Commands.Login;
using SchoolProject.Application.Features.Baskets.Commands.Update;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Users.Commands.Add;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            IDataResult<LoginUserCommandResponse> response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(AddUserCommandRequest addUserCommandRequest)
        {
            IDataResult<LoginUserCommandResponse> response = await _mediator.Send(addUserCommandRequest);
            return Ok(response);
        }
    }
}

