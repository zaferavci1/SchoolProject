using System;
using MediatR;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.PublicProfiles.Queries.GetAll
{
	public class GetAlllPublicProfileQueryResponse : IRequest<IDataResult<GetAllPublicProfilesDTO>>, IDTO
    {
        public List<GetAllPublicProfilesDTO> PublicProfiles { get; set; }
        public int TotalPublicProfilesCount { get; set; }
    }
}

