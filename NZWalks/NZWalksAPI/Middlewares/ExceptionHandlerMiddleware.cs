using System.Linq.Expressions;
using System.Net;

namespace NZWalksAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate request;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate request)
        {
            this.logger = logger;
            this.request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                logger.LogError(ex, $"ErrorId: {errorId} - An unhandled exception has occurred: {ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    ErrorId = errorId,
                    Message = "An unexpected error occurred. Please use the ErrorId when contacting support."
                });

            }
        }

    }
}
