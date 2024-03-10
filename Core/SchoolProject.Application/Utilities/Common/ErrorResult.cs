using System;
namespace SchoolProject.Application.Utilities.Common
{
	public class ErrorResult : Result
	{
        public ErrorResult(string message) : base(message, false) { }
        public ErrorResult() : base(false) { }  
    }
}

