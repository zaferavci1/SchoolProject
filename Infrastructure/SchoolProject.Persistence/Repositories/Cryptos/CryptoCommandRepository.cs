using System; 
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;
using SchoolProject.Application.Abstraction.Repository.Cryptos;

namespace SchoolProject.Persistence.Repositories.Cryptos
{
	public class CryptoCommandRepository : CommandRepository<Crypto> ,ICryptoCommandRepository
	{
		public CryptoCommandRepository(SchoolProjectDbContext schoolProjectDbContext) : base(schoolProjectDbContext)
		{
		}
	}
}

