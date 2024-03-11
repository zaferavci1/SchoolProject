using System;
using SchoolProject.Application.Abstraction.Repository.Baskets;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence.Repositories.Baskets
{
	public class BasketQueryRepository : QueryRepository<Basket>, IBasketQueryRepository
	{
		public BasketQueryRepository(SchoolProjectDbContext context ): base(context) { }
	}
}


