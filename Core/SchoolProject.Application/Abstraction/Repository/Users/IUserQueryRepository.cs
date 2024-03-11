using System;
using SchoolProject.Application.Abstraction.Repository;
using SchoolProject.Domain.Entities;
namespace SchoolProject.Application.Abstraction.Repository.Users
{
    public interface IUserQueryRepository : IQueryRepository<User>
    {
    }
}

