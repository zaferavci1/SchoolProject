using System;
using SchoolProject.Domain.Application.Abstraction.Repository.Cryptos;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Cryptos
{
	public class CryptoCommandRepository : CommandRepository<Crypto> ,ICryptoCommandRepository
	{
		public CryptoCommandRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

