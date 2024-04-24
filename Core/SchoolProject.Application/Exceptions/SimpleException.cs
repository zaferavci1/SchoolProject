using System;
using SchoolProject.Application.Abstraction.DTOs;

namespace SchoolProject.Application.Exceptions
{
    public class SimpleErrorDTO :IDTO
    {
        public string Message { get; set; }
        public SimpleErrorDTO()
        {

        }
        public SimpleErrorDTO(string message)
        {
            Message = message;
        }
    }
}

