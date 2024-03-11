using System;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Users
{
	public class UserCommandRepository : CommandRepository<User> , IUserCommandRepository
	{
		public UserCommandRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

