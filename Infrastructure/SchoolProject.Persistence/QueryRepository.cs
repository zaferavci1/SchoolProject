using System;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;
using SchoolProject.Persistence.Context;

namespace SchoolProject.Persistence
{
	public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
	{
        private readonly SchoolProjectDbContext _context;
        public QueryRepository(SchoolProjectDbContext schoolProjectDbContext) => _context = schoolProjectDbContext;

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table.AsQueryable();

        public async Task<T> GetByIdAsync(string id) => await Table.AsQueryable().FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
    }
}

