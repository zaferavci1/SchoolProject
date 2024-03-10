using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Delete
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, IDataResult<BasketDTO>>
    {
        private IBasketService _service;
        public DeleteBasketCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<IDataResult<BasketDTO>> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        {
            BasketDTO basketDTO = await _service.DeleteAsync(request.Id);
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Silindi", basketDTO);
        }
    }

}

