using System;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.Add
{
    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommandRequest, IDataResult<BasketDTO>>
	{
		private IBasketService _service;
        public AddBasketCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<IDataResult<BasketDTO>> Handle(AddBasketCommandRequest request, CancellationToken cancellationToken)
        {
            BasketDTO basketDTO = await _service.AddAsync(new() { BasketName = request.BasketName });
            return new SuccessDataResult<BasketDTO>("Sepet Başarıyla Oluşturuldu", basketDTO);

        }
    } 
}

