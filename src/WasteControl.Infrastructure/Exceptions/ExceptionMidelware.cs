using Humanizer;
using Microsoft.AspNetCore.Http;
using WasteControl.Core.Exceptions;

namespace WasteControl.Infrastructure.Exceptions
{
    internal sealed class ExceptionMidelware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                await HandleExceptionAsync(exception, context);
            }
        }

        private async Task HandleExceptionAsync(Exception exceptions, HttpContext context)
        {
            var (statusCode, error) = exceptions switch
            {
                BaseException  => (StatusCodes.Status400BadRequest, new Error(exceptions.GetType()
                .Name.Underscore().Replace("_exception", string.Empty), exceptions.Message)),
                _ => (StatusCodes.Status500InternalServerError, new Error("error", "Something went wrong"))
            };

            context.Response.StatusCode = statusCode;
            context.Response.WriteAsJsonAsync(error);
        }
    }

    internal record Error(string Code, string Reason);
}