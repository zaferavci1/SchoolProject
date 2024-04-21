	using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Domain.Entities
{
	public class User : BaseEntity
	{

        public string NickName { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Mail { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }


        public List<UserFollower> Followers { get; set; }
		public List<UserFollower> Followees { get; set; }

		public List<Post> Posts { get; set; }
        public List<PostLike> PostLikes { get; set; }

        public List<Comment> Comments { get; set; }
        public List<CommentLike> CommentLikes { get; set; }

        public List<Basket> Basket { get; set; }
        public List<BasketLike> BasketLikes { get; set; }

        public bool IsProfilePrivate { get; set; } = false;

	}
}
