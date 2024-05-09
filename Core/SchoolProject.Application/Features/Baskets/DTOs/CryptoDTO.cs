using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Features.Baskets.DTOs
{
	public class CryptoDTO : IDTO
    {

        public string? Symbol { get; set; }


        public float Cost { get; set; }
        public float Amount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

