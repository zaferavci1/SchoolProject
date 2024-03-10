using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Queries.GetAll
{
	public class GetAllBasketsQueryHandler : IRequestHandler<GetAllBasketsQueryRequest, IDataResult<GetAllBasketsQueryResponse>>
    {
        private IBasketService _service;

        public GetAllBasketsQueryHandler(IBasketService basketService)
        {
            _service = basketService;
        }

        public async Task<IDataResult<GetAllBasketsQueryResponse>> Handle(GetAllBasketsQueryRequest request, CancellationToken cancellationToken)
        {
            (List<GetAllBasketsDTO> Baskets, int TotalCount) data = await _service.GetAllAsync(request.Page, request.Size);
            return new SuccessDataResult<GetAllBasketsQueryResponse>("Müşteriler Listelendi", new() { getAllBasketsDTOs = data.Baskets, TotalCount = data.TotalCount });
        }
    }
}

