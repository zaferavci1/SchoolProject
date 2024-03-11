using System;
using MediatR;
using SchoolProject.Application.Features.PublicProfiles.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.PublicProfiles.Queries.GetById
{
	public class GetByIdPublicProfileRequest : IRequest<IDataResult<GetByIdPublicProfileDTO>>
	{
		public string? Id { get; set; }
	}
}

