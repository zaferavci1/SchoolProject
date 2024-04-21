using System;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.Commands.Follow;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.UnFollow
{
	public class UnFollowUserCommandHandler : IRequestHandler<UnFollowUserCommandRequest, IDataResult<UserDTO>>
	{

        IUserService _userService;
        UserBusinessRules _userBusinessRules;

        public UnFollowUserCommandHandler(IUserService userService, UserBusinessRules userBusinessRules)
        {
            _userService = userService;
            _userBusinessRules = userBusinessRules;
        }
        public async Task<IDataResult<UserDTO>> Handle(UnFollowUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExist(request.user1);
            await _userBusinessRules.IsUserExist(request.user2);
            await _userBusinessRules.IsUserActive(request.user1);
            await _userBusinessRules.IsUserActive(request.user2);
            await _userBusinessRules.IsUserFollowee(request.user1, request.user2);

            (UserDTO userDTO, UserDTO userDTO2) = await _userService.UnFollowAsync(request.user1, request.user2);
            var data = new SuccessDataResult<UserDTO>(userDTO.Name + " " + userDTO2.Name + "'i takipten çıkardı", userDTO);
            return data;
        }
    }
}

