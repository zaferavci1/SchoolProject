using System;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository.Posts
{
	public interface IPostQueryRepository : IQueryRepository<Post>
	{
	}
}

