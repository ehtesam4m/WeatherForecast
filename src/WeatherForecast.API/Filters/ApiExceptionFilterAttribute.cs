using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WeatherForecast.Application.Exceptions;
using WeatherForecast.Domain.Common.Execptions;

namespace WeatherForecast.API.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {

        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly ILogger<ApiExceptionFilterAttribute> _logger;

        public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger) {
            
            _logger = logger;
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(DomainValidationExeption), HandleValidationException },
                { typeof(EntityAlreadyExistsException), HandleInvalidOperationExecption },
                { typeof(NotFoundException), HandleNotFoundException }
            };

        }
        

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, $"An error occured: {context.Exception.Message}");
            
            HandleException(context);
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            var type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknowException(context);
        }

       

        private void HandleValidationException(ExceptionContext context)
        {
            HandleBadRequestException(context, "Validation Error", context.Exception.Message);
        }

        private void HandleBadRequestException(ExceptionContext context, string title, string message)
        {
            HandleError(context, StatusCodes.Status400BadRequest, title, "https://tools.ietf.org/html/rfc7231#section-6.5.1", message);
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            HandleError(context, StatusCodes.Status404NotFound, "The specified resource was not found.", "https://tools.ietf.org/html/rfc7231#section-6.5.4", context.Exception.Message);
        }

        private void HandleInvalidOperationExecption(ExceptionContext context)
        {
            HandleError(context, StatusCodes.Status409Conflict, "Invalid Operation.", "https://tools.ietf.org/html/rfc7231#section-6.5.8", context.Exception.Message);
        }

        private void HandleUnknowException(ExceptionContext context)
        {
            HandleError(context, StatusCodes.Status500InternalServerError, "An error occurred while processing your request.", "https://tools.ietf.org/html/rfc7231#section-6.6.1");
        }

        
        private void HandleError(ExceptionContext context, int statusCode, string title, string type, string message = "")
        {
            var details = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = message
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
