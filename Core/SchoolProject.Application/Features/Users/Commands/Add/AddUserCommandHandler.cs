
using Mapster;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Abstraction.Token;
using SchoolProject.Application.Features.Auth.Commands.Login;
using SchoolProject.Application.Features.Auth.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Users.Commands.Add
{
	public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, IDataResult<LoginUserCommandResponse>>
	{
        IAuthService _authService;
        UserBusinessRules _userBusinessRules;
        readonly ITokenHandler _tokenHandler;
        private readonly IDataProtector userDataProtector;
        public AddUserCommandHandler(IAuthService authService, IDataProtectionProvider dataProtectionProvider, IUserService userService, UserBusinessRules userBusinessRules, ITokenHandler tokenHandler)
        {
            _authService = authService;
            _userBusinessRules = userBusinessRules;
            _tokenHandler = tokenHandler;
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
        }

        public async Task<IDataResult<LoginUserCommandResponse>> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsEmailExistsAsync(request.Mail);
            await _userBusinessRules.IsNicNamekExistsAsync(request.NickName);
            await _userBusinessRules.IsPhoneNumberExistAsync(request.PhoneNumber);

            UserDTO userDTO = await _authService.CreateAsync(request);
            userDTO.Id = userDataProtector.Unprotect(userDTO.Id);
            User user = userDTO.Adapt<User>();
            
            Token token = _tokenHandler.CreateAccessToken(15, user);
            userDTO.Id = userDataProtector.Protect(userDTO.Id);
            return new SuccessDataResult<LoginUserCommandResponse>("başarılı", new LoginUserCommandResponse()
            {
                UserDTO = userDTO,
                TokenDTO = token.Adapt<TokenDTO>()

                
            }) ;
        }
    }
}

