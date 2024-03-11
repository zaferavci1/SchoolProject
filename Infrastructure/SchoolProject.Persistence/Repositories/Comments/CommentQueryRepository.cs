using System;
using SchoolProject.Application.Abstraction.Repository.Comments;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Comments
{
	public class CommentQueryRepository : QueryRepository<Comment> , ICommentQueryRepository
	{
		public CommentQueryRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

