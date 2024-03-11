using System;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository.Cryptos
{
	public interface ICryptoCommandRepository : ICommandRepository<Crypto>
	{
	}
}

