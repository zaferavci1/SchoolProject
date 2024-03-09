 using System;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Baskets;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence.Services
{
	public class BasketService : IBasketService
	{
        private readonly IBasketQueryRepository basketQueryRepository;
        private readonly IBasketCommandRepository basketCommandRepository;

        public BasketService(IBasketCommandRepository basketCommandRepository, IBasketQueryRepository basketQueryRepository)
        {
            this.basketCommandRepository = basketCommandRepository;
            this.basketQueryRepository = basketQueryRepository;
        }

        public async Task<BasketDTO> AddAsync(AddBasketDTO addBasketDTO)
        {
            Basket basket = await basketCommandRepository.AddAsync(new() { BasketName = addBasketDTO.BasketName });
            await basketCommandRepository.SaveAsync();
            return new() { Id= Convert.ToString(basket.Id),BasketName = basket.BasketName };
        }

        public async Task<BasketDTO> DeleteAsync(string id)
        {
            Basket basket = await basketCommandRepository.RemoveAsync(id);
            await basketCommandRepository.SaveAsync();
            return new() { Id = id, BasketName = basket.BasketName };

        }

        public async Task<(List<GetAllBasketsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => (await basketQueryRepository.GetAll().Where(b => b.IsActive == true).Include(b => b.Cryptos).Skip(page * size).Take(size).Select(b => new GetAllBasketsDTO()
        {
          Id = Convert.ToString(b.Id),
          BasketName = b.BasketName,
          Cryptos = b.Cryptos
        }).ToListAsync() ,await  basketQueryRepository.GetAll().CountAsync());

        public async Task<GetByIdBasketDTO> GetByIdAsync(string id)
        {
            Basket basket = await basketQueryRepository.Table.Include(b => b.Cryptos).FirstOrDefaultAsync(b => b.Id == Guid.Parse(id));

            return new() { Id = id, BasketName = basket.BasketName, Cryptos = basket.Cryptos };
        }

        public async Task<BasketDTO> UpdateAsync(UpdateBasketDTO updateBasketDTO)
        {
            Basket basket = await basketQueryRepository.Table.Include(b => b.Cryptos).FirstOrDefaultAsync(b => b.Id == Guid.Parse(updateBasketDTO.Id));
            basket.BasketName = updateBasketDTO.BasketName;
            basketCommandRepository.Update(basket);
            await basketCommandRepository.SaveAsync();
            return new() {Id=Convert.ToString(basket.Id), BasketName = basket.BasketName };
        }
    }
}

