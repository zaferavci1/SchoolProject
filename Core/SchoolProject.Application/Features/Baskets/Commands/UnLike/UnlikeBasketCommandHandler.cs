using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.Commands.Like;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Baskets.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.UnLike
{
    public class UnlikeBasketCommandHandler : IRequestHandler<UnLikeBasketCommandRequest, IDataResult<BasketDTO>>
    {
        private IBasketService _basketService;
        UserBusinessRules _userBusinessRules;
        BasketBusinessRules _basketBusinessRules;
        public UnlikeBasketCommandHandler(IBasketService basketService, BasketBusinessRules basketBusinessRules, UserBusinessRules userBusinessRules)
        {
            _basketService = basketService;
            _basketBusinessRules = basketBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<BasketDTO>> Handle(UnLikeBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            await _basketBusinessRules.IsBasketExistAsync(request.Id);
            await _basketBusinessRules.IsBasketAlreadyLikedAsync(request.Id, request.UserId);
            BasketDTO basketDTO = await _basketService.UnLikeAsync(request.Id, request.UserId);
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Begenildi", basketDTO);

        }
    }
}
