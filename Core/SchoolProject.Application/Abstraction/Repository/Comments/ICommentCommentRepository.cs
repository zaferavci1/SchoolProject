using System;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository.Comments
{
	public interface ICommentCommandRepository : ICommandRepository<Comment>
	{
	}
}

