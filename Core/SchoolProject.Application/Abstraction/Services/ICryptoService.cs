using System;
using SchoolProject.Application.Features.Baskets.DTOs;
using SchoolProject.Application.Features.Comments.DTOs;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Services
{
	public interface ICryptoService
	{
        Task<CryptoDTO> AddAsync(AddCryptoDTO addCryptoDTO);
        Task<CryptoDTO> DeleteAsync(string id);
    }
}

