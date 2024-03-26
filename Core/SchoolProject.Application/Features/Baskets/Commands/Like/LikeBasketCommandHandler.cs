using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Like
{
	public class LikeBasketCommandHandler : IRequestHandler<LikeBasketCommandRequest, IDataResult<BasketDTO>>
	{
        private IBasketService _basketService;
        public LikeBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IDataResult<BasketDTO>> Handle(LikeBasketCommandRequest request, CancellationToken cancellationToken)
        {
            BasketDTO basketDTO = await _basketService.LikeAsync(request.Id , request.UserId);
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Begenildi", basketDTO);

        }
    }
}

