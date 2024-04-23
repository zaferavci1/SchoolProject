using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.PublicProfiles.Queries.GetAll
{
    public class GetAllPublicProfileQueryHandler : IRequestHandler<GetAllPublicProfileQueryRequest, IDataResult<GetAlllPublicProfileQueryResponse>>
    {
        private IPublicProfileService _publicProfileService;

        public GetAllPublicProfileQueryHandler(IPublicProfileService publicProfileService)
        {
            _publicProfileService = publicProfileService;
        }

        public async Task<IDataResult<GetAlllPublicProfileQueryResponse>> Handle(GetAllPublicProfileQueryRequest request, CancellationToken cancellationToken)
        {

            if (request.Page < 0 || request.Size < 0)
            {
                throw new Exception("Page or Size cannot be less than 0");
            }
            (List<GetAllPublicProfilesDTO> PublicProfiles, int totalCount) data = await _publicProfileService.GetAllAsync(request.Page, request.Size);
            return new SuccessDataResult<GetAlllPublicProfileQueryResponse>("Data listelendi", new GetAlllPublicProfileQueryResponse() { PublicProfiles = data.PublicProfiles, TotalPublicProfilesCount = data.totalCount });

        }
    }
}

