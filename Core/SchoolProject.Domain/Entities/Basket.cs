using System;
namespace SchoolProject.Domain.Entities
{
	public class Basket : BaseEntity
    {
		public string BasketName { get; set; }
		public Guid UserId { get; set; }
        public List<Crypto> Cryptos { get; set; }
		public float Cost { get; set; }
		public float Profit { get; set; }
		public int LikeCount { get; set; }
		public bool IsPrivate { get; set; } = false;
	}
}
