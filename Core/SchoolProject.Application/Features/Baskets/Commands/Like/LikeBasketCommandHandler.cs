using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Baskets.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Like
{
	public class LikeBasketCommandHandler : IRequestHandler<LikeBasketCommandRequest, IDataResult<BasketDTO>>
	{
        private IBasketService _basketService;
        UserBusinessRules _userBusinessRules;
        BasketBusinessRules _basketBusinessRules;

        public LikeBasketCommandHandler(IBasketService basketService, UserBusinessRules userBusinessRules, BasketBusinessRules basketBusinessRules)
        {
            _basketService = basketService;
            _userBusinessRules = userBusinessRules;
            _basketBusinessRules = basketBusinessRules;
        }

        public async Task<IDataResult<BasketDTO>> Handle(LikeBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            await _basketBusinessRules.IsBasketExistAsync(request.Id);
            await _basketBusinessRules.IsBasketActiveAsync(request.Id);
            await _basketBusinessRules.IsBasketAlreadyLikedAsync(request.Id, request.UserId);

            BasketDTO basketDTO = await _basketService.LikeAsync(request.Id , request.UserId);
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Begenildi", basketDTO);

        }
    }
}

