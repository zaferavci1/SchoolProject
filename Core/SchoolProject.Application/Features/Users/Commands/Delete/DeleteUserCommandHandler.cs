using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, IDataResult<UserDTO>>
    {
        private IUserService _userService;
        UserBusinessRules _userBusinessRules;

        public DeleteUserCommandHandler(IUserService userService, UserBusinessRules userBusinessRules)
        {
            _userService = userService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<UserDTO>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.Id);
            await _userBusinessRules.IsUserActiveAsync(request.Id);

            UserDTO userDTO = await _userService.DeleteAsync(request.Id);
            return new SuccessDataResult<UserDTO>(userDTO.Name + "Kullanıcı Silindi.", userDTO);
        }
    }
}

