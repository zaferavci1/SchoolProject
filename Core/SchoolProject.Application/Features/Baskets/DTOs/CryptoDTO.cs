using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.Baskets.DTOs
{
	public class CryptoDTO : IDTO
    {
        public string? CurrencyId { get; set; }

        public string? Symbol { get; set; }

        public string? Name { get; set; }

        public float Cost { get; set; }

        public float Profit { get; set; }

        public float CurrentPrice { get; set; }
    }
}

