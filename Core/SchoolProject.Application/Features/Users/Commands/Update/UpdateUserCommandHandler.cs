using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, IDataResult<UserDTO>>
    {
        IUserService _userService;
        UserBusinessRules _userBusinessRules;

        public UpdateUserCommandHandler(IUserService userService, UserBusinessRules userBusinessRules)
        {
            _userService = userService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<UserDTO>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.Id);
            await _userBusinessRules.IsUserActiveAsync(request.Id);
            await _userBusinessRules.IsEmailsOwnerCorrectAsync(request.Mail,request.Id);
            await _userBusinessRules.IsNicNamesOwnerCorrectAsync(request.NickName, request.Id);
            await _userBusinessRules.IsPhoneNumbersOwnerCorrectAsync(request.PhoneNumber, request.Id);
            UserDTO userDTO = await _userService.UpdateAsync(request.Adapt<UpdateUserDTO>());
            return new SuccessDataResult<UserDTO>(userDTO.Name + "Kullanıcı Güncellendi.", userDTO);
        }
    }
}

