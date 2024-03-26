using System;
namespace SchoolProject.Domain.Entities
{
	public class Comment : BaseEntity
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<Comment> ReplyComments { get; set; }
        public List<CommentLike> CommentLikes{ get; set; }
        public string Content { get; set; }
		public int LikeCount { get; set; }
		
	}
}
