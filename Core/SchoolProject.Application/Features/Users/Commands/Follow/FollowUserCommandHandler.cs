using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Follow
{
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommandRequest, IDataResult<UserDTO>>
	{

        IUserService _userService;
        UserBusinessRules _userBusinessRules;

        public FollowUserCommandHandler(IUserService userService, UserBusinessRules userBusinessRules)
        {
            _userService = userService;
            _userBusinessRules = userBusinessRules;
        }
        public async Task<IDataResult<UserDTO>> Handle(FollowUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.user1);
            await _userBusinessRules.IsUserExistAsync(request.user2);
            await _userBusinessRules.IsUserActiveAsync(request.user1);
            await _userBusinessRules.IsUserActiveAsync(request.user2);
            await _userBusinessRules.UserAllReadyFollowedAsync(request.user1, request.user2);

            (UserDTO userDTO, UserDTO userDTO2) = await _userService.FollowAsync(request.user1, request.user2);
            var data = new SuccessDataResult<UserDTO>(userDTO.Name + " "+ userDTO2.Name  +"'i takip etti", userDTO);
            return data;
        }
    }
}

