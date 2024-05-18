using System;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Exceptions;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Features.Users.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.PublicProfiles.Queries.GetUserByNickName
{
    public record GetUserByNickNameQueryRequest(string NickName)
    : IRequest<IDataResult<GetByIdPublicProfileDTO>>;
    public class GetUserByNickNameQueryHandler : IRequestHandler<GetUserByNickNameQueryRequest, IDataResult<GetByIdPublicProfileDTO>>
    {
        private IPublicProfileService _publicProfileService;
        private readonly IDataProtector userDataProtector;
        IUserQueryRepository _userQueryRepository;

        public GetUserByNickNameQueryHandler(IDataProtectionProvider dataProtectionProvider, IUserQueryRepository userQueryRepository, IPublicProfileService publicProfileService)
        {
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
            _userQueryRepository = userQueryRepository;
            _publicProfileService = publicProfileService;
        }

        public async Task<IDataResult<GetByIdPublicProfileDTO>> Handle(GetUserByNickNameQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.Table.FirstOrDefaultAsync(u => u.NickName == request.NickName);
            if (user == null) throw new CustomException<UserDTO>("User Not Found");
            if (!user.IsActive) throw new CustomException<UserDTO>("User Not Active");
            var userDTO = await _publicProfileService.GetByIdAsync(userDataProtector.Protect(user.Id.ToString()));
            return new SuccessDataResult<GetByIdPublicProfileDTO>("Kullanıcı Getirildi.", userDTO);

        }

    }
}

