using System;
namespace SchoolProject.Domain.Entities
{
	public class Comment : BaseEntity
    {
        public Guid PostID { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<Comment> ReplyComments { get; set; }
		public string Content { get; set; }
		public int LikeCount { get; set; }
		
	}
}
