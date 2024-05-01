using Mapster;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Users.Queries.GetAllUserExceptUsersFollowees;

public record GetAllUserExceptUsersFolloweesRequest(string Id)
    : IRequest<IDataResult<DTOs.GetAllUserExceptUsersFolloweesDTO>>;
public class GetAllUserExceptUsersFolloweesHandler :IRequestHandler<GetAllUserExceptUsersFolloweesRequest, IDataResult<DTOs.GetAllUserExceptUsersFolloweesDTO>>
{
    
    private IUserService _userService;
    private readonly IDataProtector userDataProtector;
    UserBusinessRules _userBusinessRules;
    private IUserQueryRepository _queryRepository;
    
    public GetAllUserExceptUsersFolloweesHandler(IDataProtectionProvider dataProtectionProvider,UserBusinessRules userBusinessRules, IUserService userService, IUserQueryRepository queryRepository)
    {
        userDataProtector = dataProtectionProvider.CreateProtector("Users");
        _userBusinessRules = userBusinessRules;
        _userService = userService;
        _queryRepository = queryRepository;
    }
    public async Task<IDataResult<DTOs.GetAllUserExceptUsersFolloweesDTO>> Handle(GetAllUserExceptUsersFolloweesRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.IsUserExistAsync(request.Id);
        await _userBusinessRules.IsUserActiveAsync(request.Id);
        
        var currentUser = await _queryRepository.GetAll()
            .Include(u => u.Followees)
            .FirstOrDefaultAsync(u => u.Id == Guid.Parse(userDataProtector.Unprotect(request.Id)) && u.IsActive == true);

            List<User> users = await _queryRepository.GetAll().Where(u => u.IsActive).ToListAsync();
            users = users.Where(u => !currentUser.Followees.Any(f => f.FolloweeId == u.Id)).ToList();

        GetAllUserExceptUsersFolloweesDTO data = new();
        data.UserDtos = users.Select(u => u.Adapt<UserDTO>()).ToList();
        foreach (var user in data.UserDtos)
        {
            user.Id = userDataProtector.Protect(user.Id);
        }
        
        return new SuccessDataResult<GetAllUserExceptUsersFolloweesDTO>("Veriler listelendi",data);
    }
}