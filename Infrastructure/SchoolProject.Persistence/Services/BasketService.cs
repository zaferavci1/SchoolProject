﻿ using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Baskets;
using SchoolProject.Application.Abstraction.Services;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Services
{
	public class BasketService : IBasketService
	{
        private readonly IBasketQueryRepository basketQueryRepository;
        private readonly IBasketCommandRepository basketCommandRepository;
        private readonly IDataProtector basketDataProtector;
        private readonly IDataProtector userDataProtector;
        private readonly SchoolProjectDbContext _context;

        public BasketService(IBasketCommandRepository basketCommandRepository, IBasketQueryRepository basketQueryRepository, IDataProtectionProvider dataProtectionProvider, IDataProtectionProvider basketdataProtector, SchoolProjectDbContext context)
        {
            this.basketCommandRepository = basketCommandRepository;
            this.basketQueryRepository = basketQueryRepository;
            basketDataProtector = dataProtectionProvider.CreateProtector("Baskets");
            userDataProtector = dataProtectionProvider.CreateProtector("Users");
            _context = context;
        }

        public async Task<BasketDTO> AddAsync(AddBasketDTO addBasketDTO)
        {
            
            Basket basket = await basketCommandRepository.AddAsync(new() {UserId = Guid.Parse(userDataProtector.Unprotect(addBasketDTO.UserId)), BasketName = addBasketDTO.BasketName });
            await basketCommandRepository.SaveAsync();
            return new()
            {
                Id = basketDataProtector.Protect(basket.Id.ToString()),
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
                Id = basketDataProtector.Protect(id),
                BasketName = basket.BasketName,
                LikeCount = basket.LikeCount
            };

        }

        public async Task<(List<GetAllBasketsDTO>, int totalCount)> GetAllAsync(int page, int size)
        => (await basketQueryRepository.GetAll().Where(b => b.IsActive == true).Include(b => b.Cryptos).Skip(page * size).Take(size).Select(b => new GetAllBasketsDTO()
        {
              Id = basketDataProtector.Protect(b.Id.ToString()),
              BasketName = b.BasketName,
              Cryptos = b.Cryptos,
              LikeCount = b.LikeCount
        }).ToListAsync() ,await  basketQueryRepository.GetAll().CountAsync());

        public async Task<GetByIdBasketDTO> GetByIdAsync(string id)
        {
            Basket basket = await basketQueryRepository.Table.Include(b => b.Cryptos).FirstOrDefaultAsync(b => b.Id == Guid.Parse(basketDataProtector.Unprotect(id)));

            return new()
            {
                Id = basketDataProtector.Protect(id),
                BasketName = basket.BasketName,
                Cryptos = basket.Cryptos,
                LikeCount = basket.LikeCount
            };
        }

        public async Task<BasketDTO> LikeAsync(string id, string userId)
        {
            Basket? basket = await basketQueryRepository.Table.Include(b => b.Cryptos).FirstOrDefaultAsync(b => b.Id == Guid.Parse(basketDataProtector.Unprotect(id)));
            basket.LikeCount += 1;
            BasketLike bl = new()
            {
                BasketId = Guid.Parse(basketDataProtector.Unprotect(id)),
                UserId = Guid.Parse(userDataProtector.Unprotect(userId))
            };
            _context.BasketLikes.Add(bl);
            basketCommandRepository.Update(basket);
            await basketCommandRepository.SaveAsync();
            return new()
            {
                Id = basketDataProtector.Protect(basket.Id.ToString()),
                BasketName = basket.BasketName,
                LikeCount = basket.LikeCount
            };

        }

        public async Task<BasketDTO> UnLikeAsync(string id, string userId)
        {
            Basket? basket = await basketQueryRepository.Table.Include(b => b.Cryptos).FirstOrDefaultAsync(b => b.Id == Guid.Parse(basketDataProtector.Unprotect(id)));
            basket.LikeCount -= 1;
            BasketLike bl = new()
            {
                BasketId = Guid.Parse(basketDataProtector.Unprotect(id)),
                UserId = Guid.Parse(userDataProtector.Unprotect(userId))
            };
            _context.BasketLikes.Remove(bl);
            basketCommandRepository.Update(basket);
            await basketCommandRepository.SaveAsync();
            return new()
            {
                Id = basketDataProtector.Protect(basket.Id.ToString()),
                BasketName = basket.BasketName,
                LikeCount = basket.LikeCount
            };
        }

        public async Task<BasketDTO> UpdateAsync(UpdateBasketDTO updateBasketDTO)
        {
            Basket basket = await basketQueryRepository.Table.Include(b => b.Cryptos).FirstOrDefaultAsync(b => b.Id == Guid.Parse(basketDataProtector.Unprotect(updateBasketDTO.Id)));
            basket.BasketName = updateBasketDTO.BasketName;
            basketCommandRepository.Update(basket);
            await basketCommandRepository.SaveAsync();
            return new()
            {
                Id = basketDataProtector.Protect(basket.Id.ToString()),
                BasketName = basket.BasketName,
                LikeCount = basket.LikeCount
            };
        }
    }
}

