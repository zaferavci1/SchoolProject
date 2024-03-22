 using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Baskets;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services
{
	public class BasketService : IBasketService
	{
        private readonly IBasketQueryRepository basketQueryRepository;
        private readonly IBasketCommandRepository basketCommandRepository;
        private readonly IDataProtector dataProtector;

        public BasketService(IBasketCommandRepository basketCommandRepository, IBasketQueryRepository basketQueryRepository, IDataProtectionProvider dataProtectionProvider)
        {
            this.basketCommandRepository = basketCommandRepository;
            this.basketQueryRepository = basketQueryRepository;
            dataProtector = dataProtectionProvider.CreateProtector("Baskets");

        }

        public async Task<BasketDTO> AddAsync(AddBasketDTO addBasketDTO)
        {
            
            Basket basket = await basketCommandRepository.AddAsync(new() { BasketName = addBasketDTO.BasketName });
            await basketCommandRepository.SaveAsync();
            return new()
            {
                Id = dataProtector.Protect(basket.Id.ToString()),
                BasketName = basket.BasketName,
                LikeCount = basket.LikeCount
            };
        }

        public async Task<BasketDTO> DeleteAsync(string id)
        {
            Basket basket = await basketCommandRepository.RemoveAsync(id);
            await basketCommandRepository.SaveAsync();
            return new()
            {
                Id = dataProtector.Protect(id),
                BasketName = basket.BasketName,
                LikeCount = basket.LikeCount
            };

        }

        public async Task<(List<GetAllBasketsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => (await basketQueryRepository.GetAll().Where(b => b.IsActive == true).Include(b => b.Cryptos).Skip(page * size).Take(size).Select(b => new GetAllBasketsDTO()
        {
              Id = dataProtector.Protect(b.Id.ToString()),
              BasketName = b.BasketName,
              Cryptos = b.Cryptos,
              LikeCount = b.LikeCount
        }).ToListAsync() ,await  basketQueryRepository.GetAll().CountAsync());

        public async Task<GetByIdBasketDTO> GetByIdAsync(string id)
        {
            Basket basket = await basketQueryRepository.Table.Include(b => b.Cryptos).FirstOrDefaultAsync(b => b.Id == Guid.Parse(dataProtector.Unprotect(id)));

            return new()
            {
                Id = dataProtector.Protect(id),
                BasketName = basket.BasketName,
                Cryptos = basket.Cryptos,
                LikeCount = basket.LikeCount
            };
        }

        public async Task<BasketDTO> LikeAsync(string id)
        {
            Basket basket = await basketQueryRepository.Table.Include(b => b.Cryptos).FirstOrDefaultAsync(b => b.Id == Guid.Parse(dataProtector.Unprotect(id)));
            basket.LikeCount += 1;
            basketCommandRepository.Update(basket);
            await basketCommandRepository.SaveAsync();
            return new()
            {
                Id = dataProtector.Protect(basket.Id.ToString()),
                BasketName = basket.BasketName,
                LikeCount = basket.LikeCount
            };

        }

        public async Task<BasketDTO> UpdateAsync(UpdateBasketDTO updateBasketDTO)
        {
            Basket basket = await basketQueryRepository.Table.Include(b => b.Cryptos).FirstOrDefaultAsync(b => b.Id == Guid.Parse(dataProtector.Unprotect(updateBasketDTO.Id)));
            basket.BasketName = updateBasketDTO.BasketName;
            basketCommandRepository.Update(basket);
            await basketCommandRepository.SaveAsync();
            return new()
            {
                Id = dataProtector.Protect(basket.Id.ToString()),
                BasketName = basket.BasketName,
                LikeCount = basket.LikeCount
            };
        }
    }
}

