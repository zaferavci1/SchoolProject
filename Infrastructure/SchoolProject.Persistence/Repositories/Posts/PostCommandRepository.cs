using System;
using SchoolProject.Domain.Application.Abstraction.Repository.Posts;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Posts
{
	public class PostCommandRepository : CommandRepository<Post> , IPostCommandRepository
	{
		public PostCommandRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

