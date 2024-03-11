using System;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Application.Features.Posts.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository.PublicProfiles
{
	public interface IPublicProfileQueryRepository : IQueryRepository<PublicProfile>
	{
	}
}

