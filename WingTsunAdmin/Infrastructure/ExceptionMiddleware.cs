using Application.Wrappers;
using System.Net;

namespace WingTsunAdmin.Infrastructure
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{httpContext.Request.Path}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var requestType = httpContext.Request.Method;
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            if (requestType == "GET")
            {
                httpContext.Response.Redirect("Home/Error");
            }
            else
            {
                httpContext.Response.ContentType = "application/json";
                var response = new Response<int>("Beklenmedik bir hata oluştu.");
                response.Errors = new List<string>() { ex.GetBaseException().Message, ex.StackTrace };
                await httpContext.Response.WriteAsync(response.ToString());
            }
        }
    }

}
