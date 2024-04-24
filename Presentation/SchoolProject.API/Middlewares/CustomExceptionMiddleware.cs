using System;
using System.Net.Http.Json;
using System.Text.Json;
using SchoolProject.Application.Utilities.Common;
using System.Text.Json.Serialization;
using SchoolProject.Application.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace SchoolProject.API.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500; 

            string responseContent = HandleExceptionType(exception);
            return context.Response.WriteAsync(responseContent);
        }

        private string HandleExceptionType(Exception exception)
        {
            if (exception is ValidationException validationException)
            {
                var errors = validationException.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage })
                    .ToList();

                return JsonSerializer.Serialize(new { errors = errors });
            }
            if (exception.GetType().IsGenericType &&
                exception.GetType().GetGenericTypeDefinition() == typeof(CustomException<>))
            {
                var dataType = exception.GetType().GenericTypeArguments[0];
                var resultType = typeof(ErrorDataResult<>).MakeGenericType(dataType);
                var dataInstance = Activator.CreateInstance(dataType); // Eğer default(T) gerekiyorsa
                var result = Activator.CreateInstance(resultType, new object[] { exception.Message});

                return JsonSerializer.Serialize(result, resultType);
            }
            
            // General error handling using SimpleErrorDTO
            var defaultResult = new ErrorDataResult<SimpleErrorDTO>(new SimpleErrorDTO("An unexpected error occurred"));
            return JsonSerializer.Serialize(defaultResult);
        }

    }

}

