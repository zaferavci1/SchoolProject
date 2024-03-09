using System;
using SchoolProject.Domain.Application.Abstraction.Repository.Cryptos;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Cryptos
{
	public class CryptoQueryRepository : QueryRepository<Crypto> , ICryptoQueryRepository
	{
		public CryptoQueryRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

