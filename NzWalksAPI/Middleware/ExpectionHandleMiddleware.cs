using System.Net;

namespace NzWalksAPI.Middleware
{
    public class ExpectionHandleMiddleware
    {
        private readonly ILogger<ExpectionHandleMiddleware> _logger; //logging
        private readonly RequestDelegate next;  //nrxt middleware

        public ExpectionHandleMiddleware(ILogger<ExpectionHandleMiddleware> logger, RequestDelegate requestDelegate)
        {
            _logger = logger;
            next = requestDelegate;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorid = Guid.NewGuid();
                _logger.LogError(ex, $"{errorid}:{ex.Message}");
                httpContext.Response.StatusCode=(int)HttpStatusCode.InternalServerError;    
                httpContext.Response.ContentType="application/json";
                var error = new
                {
                    id = errorid,
                    ErrorMessage = "wrong"
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }


}
