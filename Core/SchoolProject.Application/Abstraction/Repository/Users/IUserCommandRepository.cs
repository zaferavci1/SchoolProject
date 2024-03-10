
using SchoolProject.Application.Abstraction.Repository;

using SchoolProject.Domain.Entities;

namespace SchoolProject.Application.Abstraction.Repository.Users
{
    public interface IUserCommandRepository : ICommandRepository<User>
    {
    }
}

