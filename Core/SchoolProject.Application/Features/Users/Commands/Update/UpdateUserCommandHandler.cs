using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, IDataResult<UserDTO>>
    {
        IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IDataResult<UserDTO>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            UserDTO userDTO = await _userService.UpdateAsync(
                new()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Surname = request.Surname,
                    NickName = request.NickName,
                    Mail = request.Mail,
                    PhoneNumber = request.PhoneNumber,
                    IsActive = request.IsActive,
                    Password = request.Password,
                    IsProfilePrivate = request.IsProfilePrivate
                });
            return new SuccessDataResult<UserDTO>(userDTO.Name + "Kullanıcı Güncellendi.", userDTO);
        }
    }
}

