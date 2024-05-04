using Mapster;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Users.Commands.ChangePassword;

public record ChangePasswordCommandRequest(string UserId, string OldPassword, string NewPassword)
    : IRequest<IDataResult<UserDTO>>;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommandRequest,IDataResult<UserDTO>>
{
    
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IUserCommandRepository _userCommandRepository;
    private UserBusinessRules _userBusinessRules;
    private readonly IDataProtector userDataProtector;
    public ChangePasswordCommandHandler(UserBusinessRules userBusinessRules, IUserQueryRepository userQueryRepository ,IDataProtectionProvider dataProtectionProvider, IUserCommandRepository userCommandRepository)
    {
        _userBusinessRules = userBusinessRules;
        _userQueryRepository = userQueryRepository;
        _userCommandRepository = userCommandRepository;
        userDataProtector = dataProtectionProvider.CreateProtector("Users");
    }
    public async Task<IDataResult<UserDTO>> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.IsUserExistAsync(request.UserId);
        await _userBusinessRules.IsUserActiveAsync(request.UserId);
        await _userBusinessRules.IsOldPasswordCorrect(request.UserId,request.OldPassword);
        
        User? currentUser = await _userQueryRepository.GetByIdAsync(userDataProtector.Unprotect(request.UserId));
        currentUser.Password = request.NewPassword;

         _userCommandRepository.Update(currentUser);
         await _userCommandRepository.SaveAsync();
         var userDTO = currentUser.Adapt<UserDTO>();
         userDTO.Id = userDataProtector.Protect(currentUser.Id.ToString());
         return new SuccessDataResult<UserDTO>(userDTO.Name + "Kullanıcı Şifresi.", userDTO);

    }
}