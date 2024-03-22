
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Users.Commands.Add
{
	public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, IDataResult<UserDTO>>
	{
        IUserService _userService;

        public AddUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IDataResult<UserDTO>> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            UserDTO userDTO = await _userService.AddAsync(new() { Name = request.Name, Surname = request.Surname, NickName = request.NickName, Mail = request.Mail, PhoneNumber = request.PhoneNumber, password = request.Password });
            var data = new SuccessDataResult<UserDTO>(userDTO.Name + " Eklendi", userDTO);
            return data;
        }
    }
}

