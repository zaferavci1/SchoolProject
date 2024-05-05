using System;
namespace SchoolProject.Domain.Entities
{
	public class Post:BaseEntity
	{
		public Guid UserId { get; set; }
		public User User { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int LikeCount { get; set; }
		public List<Comment> Comments { get; set; }
		public List<PostLike> PostLikes { get; set; }


	}
}

