using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.Baskets.DTOs
{
	public class AddCryptoDTO : IDTO
	{
        public string? BasketId { get; set; }

        public string? Symbol { get; set; }

        public float  Amount { get; set; }

        public float Cost { get; set; }
    }
}

