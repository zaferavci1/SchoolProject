
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Add
{
	public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, IDataResult<UserDTO>>
	{
        IAuthService _authService;
        UserBusinessRules _userBusinessRules;
        public AddUserCommandHandler(IAuthService authService, IUserService userService, UserBusinessRules userBusinessRules)
        {
            _authService = authService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<UserDTO>> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsEmailExists(request.Mail);
            await _userBusinessRules.IsNicNamekExists(request.NickName);
            await _userBusinessRules.IsPhoneNumberExist(request.PhoneNumber);

            UserDTO userDTO = await _authService.CreateAsync(request);
            var data = new SuccessDataResult<UserDTO>(userDTO.Name + " Eklendi", userDTO);
            return data;
        }
    }
}

