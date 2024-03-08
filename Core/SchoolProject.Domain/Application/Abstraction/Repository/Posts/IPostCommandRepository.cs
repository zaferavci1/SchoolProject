using System;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Domain.Application.Abstraction.Repository.Posts
{
	public interface IPostCommandRepository : ICommandRepository<Post>
	{
	}
}

