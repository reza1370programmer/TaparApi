using System.Net;
using TaparApi.Common.Api;

namespace TaparApi.Common.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
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
            await HandleGlobalExceptionAsync(httpContext, ex);
        }
    }

    private static async Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var result = new ApiResult(false, ApiResultStatusCode.ServerError, exception.Message);
        await context.Response.WriteAsJsonAsync(result);
    }
}