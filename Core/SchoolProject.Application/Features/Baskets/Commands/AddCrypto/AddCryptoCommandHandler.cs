using System;
using Mapster;
using MediatR;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.Commands.Add;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Baskets.Rules;
using SchoolProject.Application.Features.Users.Rules;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Features.Baskets.Commands.AddCrypto
{
	public class AddCryptoCommandHandler : IRequestHandler<AddCryptoCommandRequest, IDataResult<CryptoDTO>>
    {
        ICryptoService _cryptoService;
        UserBusinessRules _userBusinessRules;
        BasketBusinessRules _basketBusinessRules;


        public AddCryptoCommandHandler(ICryptoService cryptoService, UserBusinessRules userBusinessRules, BasketBusinessRules basketBusinessRules)
        {
            _cryptoService = cryptoService;
            _userBusinessRules = userBusinessRules;
            _basketBusinessRules = basketBusinessRules;
        }
        
        public async Task<IDataResult<CryptoDTO>> Handle(AddCryptoCommandRequest request, CancellationToken cancellationToken)
        {
           await _userBusinessRules.IsUserExistAsync(request.UserId);
           await _userBusinessRules.IsUserActiveAsync(request.UserId);
           await _basketBusinessRules.IsBasketExistAsync(request.BasketId);
           await _basketBusinessRules.IsBasketActiveAsync(request.BasketId);
           await _basketBusinessRules.IsOwnerCorrectAsync(request.BasketId, request.UserId);
           CryptoDTO cryptoDTO = await _cryptoService.AddAsync(request.Adapt<AddCryptoDTO>());
           return new SuccessDataResult<CryptoDTO>("Kripto Başarıyla Eklendi", cryptoDTO);

        }
    }
}

