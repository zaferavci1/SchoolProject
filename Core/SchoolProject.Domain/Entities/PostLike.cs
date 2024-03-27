using System;
namespace SchoolProject.Domain.Entities
{
	public class PostLike 
	{
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
    }
}

