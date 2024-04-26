using System;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Baskets.DTOs
{
	public class GetAllBasketsDTO : IDTO
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string BasketName { get; set; }
        public int LikeCount { get; set; }
        public List<CryptoDTO> Cryptos { get; set; }
    }
}

