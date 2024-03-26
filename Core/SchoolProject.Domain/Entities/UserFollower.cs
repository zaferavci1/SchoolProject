using System;
namespace SchoolProject.Domain.Entities
{
	public class UserFollower
	{

		public Guid FollowerId { get; set; }
		public Guid FolloweeId { get; set; }

		public User Follower { get; set; }
		public User Followee { get; set; }
	}
}

