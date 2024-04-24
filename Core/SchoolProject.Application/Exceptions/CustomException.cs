using System;
using SchoolProject.Application.Abstraction.DTOs;
using SchoolProject.Application.Utilities.Common;

namespace SchoolProject.Application.Exceptions
{
    public class CustomException<T> : Exception where T : IDTO, new()
    {
        public T Data { get; }

        public CustomException(string message) : base(message)
        {
            Data = new T();
        }
    }
}

