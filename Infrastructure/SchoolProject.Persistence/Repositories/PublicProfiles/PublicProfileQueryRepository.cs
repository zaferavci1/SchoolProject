using System;
using SchoolProject.Application.Abstraction.Repository.PublicProfiles;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.PublicProfiles
{
	public class PublicProfileQueryRepository : QueryRepository<PublicProfile> , IPublicProfileQueryRepository
	{
		public PublicProfileQueryRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

