using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Users.Commands.ChangePassword;
using SchoolProject.Application.Features.Users.Commands.Add;
using SchoolProject.Application.Features.Users.Commands.Delete;
using SchoolProject.Application.Features.Users.Commands.Follow;
using SchoolProject.Application.Features.Users.Commands.UnFollow;
using SchoolProject.Application.Features.Users.Commands.Update;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Queries.GetAll;
using SchoolProject.Application.Features.Users.Queries.GetAllUserExceptUsersFollowees;
using SchoolProject.Application.Features.Users.Queries.GetById;
using SchoolProject.Application.Features.Users.Queries.GetByIdUsersComments;
using SchoolProject.Application.Features.Users.Queries.GetByIdUsersPosts;
using SchoolProject.Application.Utilities.Common;
using SchoolProject.Infrastructure.Services;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "User")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //public async Task<IActionResult> Add(AddUserCommandRequest addUserCommandRequest)
        //{
        //    IDataResult<UserDTO> response = await _mediator.Send(addUserCommandRequest);
        //    return Ok(response);
        //}
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
        public async Task<IActionResult> Follow(FollowUserCommandRequest followUserCommandRequest)
        {
            IDataResult<UserDTO> response = await _mediator.Send(followUserCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UnFollow(UnFollowUserCommandRequest unFollowUserCommandRequest)
        {
            IDataResult<UserDTO> response = await _mediator.Send(unFollowUserCommandRequest);
            return Ok(response);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdUsersPosts([FromRoute] GetByIdUsersPostsQueryRequest getByIdUsersPostsQueryRequest)
        {
            IDataResult<GetByIdUsersPostsQueryResponse> response = await _mediator.Send(getByIdUsersPostsQueryRequest);
            return Ok(response);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdUsersComments([FromRoute] GetByIdUsersCommentsQueryRequest getByIdUsersCommentsQueryRequest)
        {
            IDataResult<GetByIdUsersCommentsQueryResponse> response = await _mediator.Send(getByIdUsersCommentsQueryRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> GetAllUserExceptUsersFollowees(GetAllUserExceptUsersFolloweesRequest exceptUsersFolloweesRequest )
        {
            IDataResult<GetAllUserExceptUsersFolloweesDTO> response = await _mediator.Send(exceptUsersFolloweesRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUsersPassword(ChangePasswordCommandRequest changePasswordCommandRequest )
        {
            IDataResult<UserDTO> response = await _mediator.Send(changePasswordCommandRequest);
            return Ok(response);
        }

    }
}

