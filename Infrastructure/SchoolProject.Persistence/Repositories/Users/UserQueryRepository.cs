using System;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Users
{
	public class UserQueryRepository : QueryRepository<User> , IUserQueryRepository
	{
		public UserQueryRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

