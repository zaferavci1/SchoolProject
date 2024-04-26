using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.PublicProfiles.Queries.GetById
{
    public class GetByIdPublicProfileHandler : IRequestHandler<GetByIdPublicProfileRequest, IDataResult<GetByIdPublicProfileDTO>>
    {
        private IPublicProfileService _publicProfileService;
        UserBusinessRules _userBusinessRules;

        public GetByIdPublicProfileHandler(IPublicProfileService publicProfileService, UserBusinessRules userBusinessRules)
        {
            _publicProfileService = publicProfileService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<GetByIdPublicProfileDTO>> Handle(GetByIdPublicProfileRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.Id);
            await _userBusinessRules.IsUserActiveAsync(request.Id);
            GetByIdPublicProfileDTO getByIdPublicProfileDTO = await _publicProfileService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdPublicProfileDTO>("Public Profiles getirildi. ", getByIdPublicProfileDTO);
        }
    }
}

