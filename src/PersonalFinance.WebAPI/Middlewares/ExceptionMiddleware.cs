using System.Net;
using Newtonsoft.Json;

namespace PersonalFinance.WebAPI.Middlewares;

public class ExceptionMiddleware 
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next , ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await this._next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e , e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private  Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));
        if (ex == null)
            throw new ArgumentNullException(nameof(ex));
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        return context.Response.WriteAsync(JsonConvert.SerializeObject(new
        {
            success = false,
            message = ex.Message,
            statusCode = (int)HttpStatusCode.BadRequest
        }));   
    }
}