using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Utilities.Common
{
    public class ErrorDataResult<T> : DataResult<T> where T : class, IDTO, new()
    {
        public ErrorDataResult(string message, T data) : base(message, false, data) { }
        public ErrorDataResult(T data) : base(false, data) { }
        public ErrorDataResult(string message) : base(message, false, default) { }
        public ErrorDataResult() : base(false, default) { }
    }
}

