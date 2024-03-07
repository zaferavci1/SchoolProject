using System;
namespace SchoolProject.Domain.Entities
{
	public class Post:BaseEntity
	{

		public string Title { get; set; }
		public string Content { get; set; }
		public int LikeCount { get; set; }
		public List<Comment> Comments { get; set; }


	}
}

