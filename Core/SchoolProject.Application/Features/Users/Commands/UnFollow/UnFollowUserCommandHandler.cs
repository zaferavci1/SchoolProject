using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.Commands.Follow;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.UnFollow
{
	public class UnFollowUserCommandHandler : IRequestHandler<UnFollowUserCommandRequest, IDataResult<UserDTO>>
	{

        IUserService _userService;

    public UnFollowUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IDataResult<UserDTO>> Handle(UnFollowUserCommandRequest request, CancellationToken cancellationToken)
    {
        (UserDTO userDTO, UserDTO userDTO2) = await _userService.UnFollowAsync(request.user1, request.user2);
        var data = new SuccessDataResult<UserDTO>(userDTO.Name + " " + userDTO2.Name + "'i takip etti", userDTO);
        return data;
    }
}
}

