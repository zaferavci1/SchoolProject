using System;
namespace SchoolProject.Domain.Entities
{
	public class Crypto : BaseEntity
    {
        public string CurrencyId { get; set; } 
        public string Symbol { get; set; } 
        public string Name { get; set; } 
        public float CurrentPrice { get; set; } 
        public float MarketCap { get; set; } 
        public float CirculatingSupply { get; set; } 
        public float Volume24h { get; set; } 
        public float PercentChange24h { get; set; }
    }
}

