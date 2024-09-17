using GlobalExceptionHandling.CustomExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalExceptionHandling
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails
            {
                Title = exception.Message,
                Detail = exception.StackTrace
            };

            problemDetails.Status = exception switch
            {
                BaseException e => (int)e.StatusCode,
                _ => (int)HttpStatusCode.InternalServerError
            };

            _logger.LogError(exception, exception.Message);

            await httpContext.Response.WriteAsJsonAsync(problemDetails,typeof(ProblemDetails), cancellationToken);

            return true;
        }
    }

    public class ProductNotFoundExceptionHandler(ILogger<ProductNotFoundException> _logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if (exception is not ProductNotFoundException e)
            {
                return false;
            }

            //handle error

            return true;
        }
    }

    public class StockExhaustedExceptionHandler(ILogger<StockExhaustedExceptionHandler> _logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if (exception is not StockExhaustedException e)
            {
                return false;
            }

            //handle error

            return true;
        }
    }

}
