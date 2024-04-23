using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Baskets.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Queries.GetById
{
    public class GetByIdBasketQueryHandler : IRequestHandler<GetByIdBasketQueryRequest, IDataResult<GetByIdBasketDTO>>
    {
        private IBasketService _service;
        BasketBusinessRules _basketBusinessRules;
        public GetByIdBasketQueryHandler(IBasketService service, BasketBusinessRules basketBusinessRules)
        {
            _service = service;
            _basketBusinessRules = basketBusinessRules;
        }

        public async Task<IDataResult<GetByIdBasketDTO>> Handle(GetByIdBasketQueryRequest request, CancellationToken cancellationToken)
        {

            await _basketBusinessRules.IsBasketExist(request.Id);
            await _basketBusinessRules.IsBasketActive(request.Id);
            GetByIdBasketDTO getByIdBasketDTO = await _service.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdBasketDTO>("Sipariş Getirildi", getByIdBasketDTO);
        }
    }
}

