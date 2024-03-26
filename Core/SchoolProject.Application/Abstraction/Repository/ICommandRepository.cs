using System;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository
{
	public interface ICommandRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> RemoveAsync(string id);
        T Update(T entity);
        Task<int> SaveAsync();
    }
}

