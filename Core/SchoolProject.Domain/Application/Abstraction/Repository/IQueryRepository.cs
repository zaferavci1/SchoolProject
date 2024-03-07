
using System;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Domain.Application.Abstraction.Repository
{
	public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(string id);
    }
}

