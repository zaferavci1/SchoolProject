using System;
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
		public List<User> Followers { get; set; }
		public List<User> Follows { get; set; }
		public List<Post> Posts { get; set; }
		public List<Basket> Basket { get; set; }
		public bool IsProfilePrivate { get; set; } = false;

	}
}
