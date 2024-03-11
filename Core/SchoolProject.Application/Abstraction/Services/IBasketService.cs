using System;
using SchoolProject.Application.Features.Baskets.DTOs;

namespace SchoolProject.Application.Abstraction.Services
{
	public interface IBasketService
	{

        Task<(List<GetAllBasketsDTO>, int totalCount)> GetAllAsync(int page, int size);
        Task<GetByIdBasketDTO> GetByIdAsync(string id);
        Task<BasketDTO> AddAsync(AddBasketDTO addBasketDTO);
        Task<BasketDTO> UpdateAsync(UpdateBasketDTO updateBasketDTO);
        Task<BasketDTO> DeleteAsync(string id);
    }
}

