using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Queries.GetById
{
    public class GetByIdBasketQueryHandler : IRequestHandler<GetByIdBasketQueryRequest, IDataResult<GetByIdBasketDTO>>
    {
        private IBasketService _service;
        public GetByIdBasketQueryHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<IDataResult<GetByIdBasketDTO>> Handle(GetByIdBasketQueryRequest request, CancellationToken cancellationToken)
        {
            GetByIdBasketDTO getByIdBasketDTO = await _service.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdBasketDTO>("Sipariş Getirildi", getByIdBasketDTO);
        }
    }
}

