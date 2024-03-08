using System;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository.PublicProfiles
{
	public interface IPublicProfileCommandRepository : ICommandRepository<GetAllPostDTO>
	{
	}
}

