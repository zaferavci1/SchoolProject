using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Utilities.Common
{
	public interface IDataResult<T> : IResult where T : class, IDTO, new()
    {
        T Data { get; }
    }
}

