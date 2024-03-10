using System;
namespace SchoolProject.Application.Utilities.Common
{
	public class SuccessResult : Result
	{
        public SuccessResult(string message) : base(message, true) { }
        public SuccessResult() : base(true) { }
    }
}

