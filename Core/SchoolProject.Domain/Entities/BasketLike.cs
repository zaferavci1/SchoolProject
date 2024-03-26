using System;
namespace SchoolProject.Domain.Entities
{
	public class BasketLike
	{
        public Guid UserId { get; set; }
        public Guid BasketId { get; set; }

        public User User { get; set; }
        public Basket Basket { get; set; }
    }
}

