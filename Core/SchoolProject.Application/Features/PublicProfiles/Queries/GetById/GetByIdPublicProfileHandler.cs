using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.PublicProfiles.Queries.GetById
{
    public class GetByIdPublicProfileHandler : IRequestHandler<GetByIdPublicProfileRequest, IDataResult<GetByIdPublicProfileDTO>>
    {
        private IPublicProfileService _publicProfileService;

        public GetByIdPublicProfileHandler(IPublicProfileService publicProfileService)
        {
            _publicProfileService = publicProfileService;
        }

        public async Task<IDataResult<GetByIdPublicProfileDTO>> Handle(GetByIdPublicProfileRequest request, CancellationToken cancellationToken)
        {
            GetByIdPublicProfileDTO getByIdPublicProfileDTO = await _publicProfileService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdPublicProfileDTO>("Public Profiles getirildi. ", getByIdPublicProfileDTO);
        }
    }
}

