using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, IDataResult<UserDTO>>
    {
        private IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IDataResult<UserDTO>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            UserDTO userDTO = await _userService.DeleteAsync(request.Id);
            return new SuccessDataResult<UserDTO>(userDTO.Name + "Kullanıcı Silindi.", userDTO);
        }
    }
}

