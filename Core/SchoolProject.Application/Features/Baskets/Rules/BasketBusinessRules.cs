using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository.Baskets;
using SchoolProject.Application.Abstraction.Repository.Users;
using SchoolProject.Application.Exceptions;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Features.Baskets.Rules
{
    public class BasketBusinessRules
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IBasketQueryRepository _basketQueryRepository;
        private readonly IDataProtector _userDataProtector;
        private readonly IDataProtector _basketDataProtector;

        public BasketBusinessRules(IUserQueryRepository userQueryRepository, IBasketQueryRepository basketQueryRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userQueryRepository = userQueryRepository;
            _basketQueryRepository = basketQueryRepository;
            _userDataProtector = dataProtectionProvider.CreateProtector("Users");
            _basketDataProtector = dataProtectionProvider.CreateProtector("Baskets");
        }

        public async Task IsBasketExist(string id)
        {
            Basket? basket = await _basketQueryRepository.GetByIdAsync(_basketDataProtector.Unprotect(id));
            if (basket == null) throw new CustomException<BasketDTO>("Basket Not Exist");
        }

        public async Task IsBasketActive(string id)
        {
            Basket? basket = await _basketQueryRepository.GetByIdAsync(_basketDataProtector.Unprotect(id));
            if (!basket.IsActive) throw new CustomException<BasketDTO>("Basket Not Active");
        }

        public async Task IsBasketAlreadyLiked(string basketId, string userId)
        {
            bool check = await _userQueryRepository.Table
                          .Include(u => u.BasketLikes)
                          .AnyAsync(u => u.BasketLikes.Any(bl => bl.BasketId == Guid.Parse(_basketDataProtector.Unprotect(basketId)) && bl.UserId == Guid.Parse(_userDataProtector.Unprotect(userId))));
            if (check) throw new CustomException<BasketDTO>("Basket Already Liked");
        }

        public async Task IsBasketLiked(string basketId, string userId)
        {
            bool check = await _userQueryRepository.Table
                          .Include(u => u.BasketLikes)
                          .AnyAsync(u => u.BasketLikes.Any(bl => bl.BasketId == Guid.Parse(_basketDataProtector.Unprotect(basketId)) && bl.UserId == Guid.Parse(_userDataProtector.Unprotect(userId))));
            if (!check) throw new CustomException<BasketDTO>("Basket Not Liked");
        }

        public async Task IsOwnerCorrect(string basketId, string userId)
        {
            Basket? basket = await _basketQueryRepository.GetByIdAsync(_basketDataProtector.Unprotect(basketId));
            if (basket.UserId != Guid.Parse(_userDataProtector.Unprotect(userId))) throw new CustomException<BasketDTO>("Owner Not Correct");
        }
    }
}
