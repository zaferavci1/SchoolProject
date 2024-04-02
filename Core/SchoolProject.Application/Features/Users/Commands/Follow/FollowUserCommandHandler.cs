using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Follow
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommandRequest, IDataResult<UserDTO>>
	{

        IUserService _userService;

        public FollowUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IDataResult<UserDTO>> Handle(FollowUserCommandRequest request, CancellationToken cancellationToken)
        {
            (UserDTO userDTO, UserDTO userDTO2) = await _userService.FollowAsync(request.user1, request.user2);
            var data = new SuccessDataResult<UserDTO>(userDTO.Name + " "+ userDTO2.Name  +"'i takip etti", userDTO);
            return data;
        }
    }
}

