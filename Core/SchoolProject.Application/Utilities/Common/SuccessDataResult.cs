using SchoolProject.Application.Abstraction.DTOs;
﻿using System;
 

namespace SchoolProject.Application.Utilities.Common
{
    public class SuccessDataResult<T> : DataResult<T> where T : class, IDTO, new()
    {
        public SuccessDataResult(string message, T data) : base(message, true, data) { }
        public SuccessDataResult(T data) : base(true, data) { }
        public SuccessDataResult(string message) : base(message, true, default) { }
        public SuccessDataResult() : base(true, default) { }
    }
}