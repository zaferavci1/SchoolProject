using System;
using MediatR;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.AddCrypto
{
	public class AddCryptoCommandRequest : IRequest<IDataResult<CryptoDTO>>
    {
        public string? UserId { get; set; }
        public string? BasketId { get; set; }
        public string? Symbol { get; set; }
        public float Amount { get; set; }
        public float Cost { get; set; }
    }
}

