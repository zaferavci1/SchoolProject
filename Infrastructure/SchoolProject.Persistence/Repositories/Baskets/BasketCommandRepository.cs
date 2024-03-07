using System;
using SchoolProject.Domain.Application.Abstraction.Repository.Baskets;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Baskets
{
	public class BasketCommandRepository : CommandRepository<Basket>, IBasketCommandRepository
	{
		public BasketCommandRepository(SchoolProjectDbContext eSchoolProjectDbContext) : base(eSchoolProjectDbContext) { }
	}
}

