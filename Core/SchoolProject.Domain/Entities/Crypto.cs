using System;
namespace SchoolProject.Domain.Entities
{
	public class Crypto : BaseEntity
    {

        public string? Symbol { get; set; }

        public float Cost { get; set; }
        public float Amount { get; set; }

        public Guid? BasketId { get; set; }
        public Basket? Basket { get; set; }
    }
}

