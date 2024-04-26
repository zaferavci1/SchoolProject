using System;
namespace SchoolProject.Domain.Entities
{
	public class Crypto : BaseEntity
    {

        public string? CurrencyId { get; set; }

        public string? Symbol { get; set; }

        public string? Name { get; set; }

        public float Cost { get; set; }

        public float Profit { get; set; }

        public float CurrentPrice { get; set; }

        public Guid? BasketId { get; set; }
        public Basket? Basket { get; set; }
    }
}

