using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.Commands.Like;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.UnLike
{
    public class UnlikeBasketCommandHandler : IRequestHandler<UnLikeBasketCommandRequest, IDataResult<BasketDTO>>
    {
        private IBasketService _basketService;
        public UnlikeBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IDataResult<BasketDTO>> Handle(UnLikeBasketCommandRequest request, CancellationToken cancellationToken)
        {
            BasketDTO basketDTO = await _basketService.UnLikeAsync(request.Id, request.UserId);
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Begenildi", basketDTO);

        }
    }
}
