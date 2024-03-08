using System;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository.Baskets
{
	public interface IBasketCommandRepository : ICommandRepository<Basket>
	{
	}
}

