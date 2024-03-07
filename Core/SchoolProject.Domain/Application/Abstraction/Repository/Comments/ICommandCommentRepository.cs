using System;
using SchoolProject.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SchoolProject.Domain.Application.Abstraction.Repository.Comments
{
	public interface ICommandCommentRepository : ICommandRepository<Comment>
	{
	}
}

