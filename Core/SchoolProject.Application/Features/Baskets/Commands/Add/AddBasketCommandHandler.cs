using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Baskets.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Add
{
    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommandRequest, IDataResult<BasketDTO>>
	{
		private IBasketService _basketService;
        UserBusinessRules _userBusinessRules;
        public AddBasketCommandHandler(IBasketService basketService, BasketBusinessRules basketBusinessRules, UserBusinessRules userBusinessRules)
        {
            _basketService = basketService;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<BasketDTO>> Handle(AddBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            BasketDTO basketDTO = await _basketService.AddAsync(request.Adapt<AddBasketDTO>());
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Oluşturuldu", basketDTO);

        }
    } 
}

