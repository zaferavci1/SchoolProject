using System;
using SchoolProject.Application.Abstraction.DTO;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Baskets.DTOs
{
	public class GetAllBasketsDTO : IDTO
	{
        public string Id { get; set; }
        public string BasketName { get; set; }
        public int LikeCount { get; set; }
        public List<Crypto> Cryptos { get; set; }
    }
}

