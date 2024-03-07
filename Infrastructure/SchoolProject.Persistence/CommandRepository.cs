using System;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Persistence
{
	public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
	{
		public CommandRepository()
		{
		}

        public DbSet<T> Table => throw new NotImplementedException();

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
