using System;
using SchoolProject.Domain.Application.Abstraction.DTO;

namespace SchoolProject.Domain.Application.Utilities.Result
{
	public interface IDataResult<T> : IResult where T : class, IDTO, new()
	{
		T Data { get; }
	}
}

