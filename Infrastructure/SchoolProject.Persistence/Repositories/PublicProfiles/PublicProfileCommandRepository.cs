using System;
using SchoolProject.Domain.Application.Abstraction.Repository.PublicProfiles;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.PublicProfiles
{
	public class PublicProfileCommandRepository : CommandRepository<PublicProfile>,IPublicProfileCommandRepository
	{
		public PublicProfileCommandRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

