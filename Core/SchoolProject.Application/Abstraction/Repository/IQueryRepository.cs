
using System;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository
{
	public interface IQueryRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(string id);
    }
}

