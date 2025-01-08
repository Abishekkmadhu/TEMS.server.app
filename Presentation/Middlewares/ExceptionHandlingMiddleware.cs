using Shared.Exceptions;

namespace Presentation.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomValidationException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var response = new
                {
                    Title = "Validation Errors",
                    Status = 400,
                    Errors = ex.Errors
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = new
                {
                    Title = "An unexpected error occurred.",
                    Status = 500,
                    Detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
