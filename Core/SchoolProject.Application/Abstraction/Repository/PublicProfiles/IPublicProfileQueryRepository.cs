using System;
using SchoolProjectß.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository.PublicProfiles
{
	public interface IPublicProfileQueryRepository : IQueryRepository<GetAllPostDTO>
	{
	}
}

