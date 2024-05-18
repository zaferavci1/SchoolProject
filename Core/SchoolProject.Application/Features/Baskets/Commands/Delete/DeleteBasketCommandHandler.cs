using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Baskets.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Delete
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, IDataResult<BasketDTO>>
    {
        private IBasketService _service;
        UserBusinessRules _userBusinessRules;
        BasketBusinessRules _basketBusinessRules;
        public DeleteBasketCommandHandler(IBasketService service, UserBusinessRules userBusinessRules, BasketBusinessRules basketBusinessRules)
        {
            _service = service;
            _userBusinessRules = userBusinessRules;
            _basketBusinessRules = basketBusinessRules;
        }

        public async Task<IDataResult<BasketDTO>> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        {

            await _userBusinessRules.IsUserExistAsync(request.UserId);
            await _userBusinessRules.IsUserActiveAsync(request.UserId);
            await _basketBusinessRules.IsBasketExistAsync(request.Id);
            await _basketBusinessRules.IsBasketActiveAsync(request.Id);
            await _basketBusinessRules.IsOwnerCorrectAsync(request.Id, request.UserId);

            BasketDTO basketDTO = await _service.DeleteAsync(request.Id);
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Silindi", basketDTO);
        }
    }

}

