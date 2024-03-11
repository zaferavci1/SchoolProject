using System;
namespace SchoolProject.Application.Utilities.Common
{
	public interface IResult
	{
        string Message { get; }
        bool IsSucceeded { get; }
    }
}

