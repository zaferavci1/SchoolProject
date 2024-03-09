using System;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Services
{
	public interface ICryptoService
	{
		Task<Crypto> GetCryptoFromAPIAsync(string CryptoId);
	}
}

