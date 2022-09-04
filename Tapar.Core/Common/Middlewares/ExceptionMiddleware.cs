using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Tapar.Core.Common.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ILogger<ExceptionMiddleware> Logger { get; set; }

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        Logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message);
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