using System;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence
{
	public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
	{
        private readonly SchoolProjectDbContext _context;

        public CommandRepository(SchoolProjectDbContext context) => context = _context;

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
            => Table.AddAsync(entity).Result.Entity;

        public async Task<T> RemoveAsync(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            entity.IsActive = false;
            return entity;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public T Update(T entity)
            => Table.Update(entity).Entity;
    }
}
