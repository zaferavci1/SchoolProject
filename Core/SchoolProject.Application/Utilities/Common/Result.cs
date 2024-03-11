using System;
namespace SchoolProject.Application.Utilities.Common
{
	public class Result : IResult
	{
        public Result(string message, bool isSucceeded) : this(isSucceeded) => this.Message = message;
        public Result(bool isSucceeded) => this.IsSucceeded = isSucceeded;

        public string Message { get; }
        public bool IsSucceeded { get; }
    }
}

