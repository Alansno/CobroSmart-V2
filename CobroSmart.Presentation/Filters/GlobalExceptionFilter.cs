using CobroSmart.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CobroSmart.Presentation.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "Se ha producido un error inesperado.";

            switch (context.Exception)
            {
                case NotFoundException notFoundEx:
                    statusCode = HttpStatusCode.NotFound;
                    message = notFoundEx.Message;
                    break;
                case UnauthorizedAccessException unauthorized:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = unauthorized.Message;
                    break;
                case DbUpdateConcurrencyException dbUpdateConcurrencyException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = dbUpdateConcurrencyException.Message;
                    break;
                default:
                    _logger.LogError(context.Exception, "Error no manejado");
                    break;
            }

            context.Result = new ObjectResult(new
            {
                message = message,
                statusCode = (int)statusCode
            })
            {
                StatusCode = (int)statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
