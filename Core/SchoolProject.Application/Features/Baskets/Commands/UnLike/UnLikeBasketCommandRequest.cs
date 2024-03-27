using System;
using MediatR;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.UnLike
{
	public class UnLikeBasketCommandRequest : IRequest<IDataResult<BasketDTO>>
    {
        public string Id { get; set; }
        public string UserId { get; set; }

    }
}

