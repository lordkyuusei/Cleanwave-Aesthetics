using Cleanwave.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Cleanwave.API.Filters
{
    public class APIExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandler;

        public APIExceptionFilter()
        {
            _exceptionHandler = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleCustomException(context);
            base.OnException(context);
        }

        private void HandleCustomException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandler.ContainsKey(type))
            {
                _exceptionHandler[type].Invoke(context);
            }
            else if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
            }
            else
            {
                HandleUnknownException(context);
            }
            throw new NotImplementedException();
        }

        private void HandleValidationException(ExceptionContext context)
        {
            ValidationException ex = context.Exception as ValidationException;
            ValidationProblemDetails details = new(ex.Errors)
            {
                Type = "ValidationException"
            };
            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        private static void HandleUnknownException(ExceptionContext context)
        {
            ProblemDetails details = new()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occured while processing your request.",
                Type = "UnknownException"
            };
            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;
        }

        private static void HandleInvalidModelStateException(ExceptionContext context)
        {
            ValidationProblemDetails details = new(context.ModelState)
            {
                Type = "ValidationProblemDetails"
            };
            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
