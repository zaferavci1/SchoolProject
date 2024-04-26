using System;
using Mapster;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Baskets;
using SchoolProject.Application.Abstraction.Repository.Cryptos;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;
using SchoolProject.Persistence.Repositories.Baskets;

namespace SchoolProject.Persistence.Services
{
    public class CryptoService : ICryptoService
	{

        private readonly ICryptoCommandRepository _cryptoCommandRepository;
        private readonly IBasketCommandRepository _basketCommandRepository;
        private readonly IBasketQueryRepository _basketQueryRepository;
        private readonly IDataProtector _basketDataProtector;
        private readonly IDataProtector _userDataProtector;
        private readonly SchoolProjectDbContext _context;
        public CryptoService(IDataProtectionProvider dataProtectionProvider, SchoolProjectDbContext context, ICryptoCommandRepository cryptoCommandRepository, IBasketCommandRepository basketCommandRepository, IBasketQueryRepository basketQueryRepository)
        {
            _basketDataProtector = dataProtectionProvider.CreateProtector("Baskets");
            _userDataProtector = dataProtectionProvider.CreateProtector("Users");
            _context = context;
            _cryptoCommandRepository = cryptoCommandRepository;
            _basketCommandRepository = basketCommandRepository;
            _basketQueryRepository = basketQueryRepository;
        }

        public async Task<CryptoDTO> AddAsync(AddCryptoDTO addCryptoDTO)
        {
            addCryptoDTO.BasketId = _basketDataProtector.Unprotect(addCryptoDTO.BasketId);
            Crypto crypto = await _cryptoCommandRepository.AddAsync(addCryptoDTO.Adapt<Crypto>());
            Basket? basket = await  _basketQueryRepository.Table.Include(c=>c.Cryptos).FirstOrDefaultAsync(b=>b.Id == crypto.BasketId);
            basket.Cryptos.Add(crypto);
            _basketCommandRepository.Update(basket);
            await _cryptoCommandRepository.SaveAsync();
            return crypto.Adapt<CryptoDTO>();

        }

        public Task<CryptoDTO> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

