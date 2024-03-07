using System;
namespace SchoolProject.Domain.Entities
{
	public class Basket : BaseEntity
    {
		public List<Crypto> Cryptos { get; set; }
		public float Profit { get; set; }
		public int LikeCount { get; set; }
		public bool IsPrivate { get; set; } = false;
	}
}
