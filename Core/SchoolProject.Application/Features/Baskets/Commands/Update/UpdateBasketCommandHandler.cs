using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Baskets.Rules;
using SchoolProject.Application.Features.Comments.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Update
{ 
	public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, IDataResult<BasketDTO>>
    {
        private IBasketService _service;
        UserBusinessRules _userBusinessRules;
        BasketBusinessRules _basketBusinessRules;
        public UpdateBasketCommandHandler(IBasketService service, BasketBusinessRules basketBusinessRules, UserBusinessRules userBusinessRules)
        {
            _service = service;
            _basketBusinessRules = basketBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<IDataResult<BasketDTO>> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {

            await _userBusinessRules.IsUserExist(request.UserId);
            await _userBusinessRules.IsUserActive(request.UserId);
            await _basketBusinessRules.IsBasketExist(request.Id);
            await _basketBusinessRules.IsBasketActive(request.Id);
            await _basketBusinessRules.IsOwnerCorrect(request.Id, request.UserId);
            BasketDTO basketDTO = await _service.UpdateAsync(request.Adapt<UpdateBasketDTO>());
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Güncellendi", basketDTO);
        }
    }
}

