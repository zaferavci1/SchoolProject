using System;
namespace SchoolProject.Domain.Entities
{
	public class Crypto : BaseEntity
    {
        public string CurrencyId { get; set; } 
        public string Symbol { get; set; } 
        public string Name { get; set; } 
        public decimal CurrentPrice { get; set; } 
        public decimal MarketCap { get; set; } 
        public decimal CirculatingSupply { get; set; } 
        public decimal Volume24h { get; set; } 
        public decimal PercentChange24h { get; set; }
    }
}

