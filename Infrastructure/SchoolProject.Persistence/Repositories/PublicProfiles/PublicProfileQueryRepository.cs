﻿using System;
using SchoolProject.Domain.Application.Abstraction.Repository.PublicProfiles;
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

