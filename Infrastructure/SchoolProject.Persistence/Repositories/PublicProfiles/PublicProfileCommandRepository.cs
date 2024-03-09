using System;
using SchoolProject.Application.Abstraction.Repository.PublicProfiles;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.PublicProfiles
{
	public class PublicProfileCommandRepository : CommandRepository<GetAllPostDTO>,IPublicProfileCommandRepository
	{
		public PublicProfileCommandRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

