using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Update
{ 
	public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, IDataResult<BasketDTO>>
    {
        private IBasketService _service;
        public UpdateBasketCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<IDataResult<BasketDTO>> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            BasketDTO basketDTO = await _service.UpdateAsync(request.Adapt<UpdateBasketDTO>());
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Güncellendi", basketDTO);
        }
    }
}

