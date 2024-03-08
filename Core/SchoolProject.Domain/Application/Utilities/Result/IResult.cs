using System;
namespace SchoolProject.Domain.Application.Utilities.Result
{
	public interface IResult
	{
        string Message { get; }
        bool IsSucceeded { get; }
    }
}

