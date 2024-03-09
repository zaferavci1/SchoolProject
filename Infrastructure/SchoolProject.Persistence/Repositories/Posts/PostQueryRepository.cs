using System;
using SchoolProject.Application.Abstraction.Repository.Posts;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Posts
{
	public class PostQueryRepository : QueryRepository<Post> , IPostQueryRepository
	{
		public PostQueryRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

