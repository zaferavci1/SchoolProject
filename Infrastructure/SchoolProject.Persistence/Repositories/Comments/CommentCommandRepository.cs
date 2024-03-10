using System;
using SchoolProject.Application.Abstraction.Repository.Comments;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Comments
{
	public class CommentCommandRepository : CommandRepository<Comment> , ICommentCommandRepository
	{
		public CommentCommandRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

