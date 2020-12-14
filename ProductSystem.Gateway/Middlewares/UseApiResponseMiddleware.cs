using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using ProductSystem.Gateway.Models;

namespace ProductSystem.Gateway.Middlewares
{
    public class UseApiResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public UseApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.Value.Contains("/swagger");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var memoryStream = new MemoryStream())
            {
                ApiResponse result = null;
                if (!IsSwagger(context))
                {
                    var currentBody = context.Response.Body;
                    context.Response.Body = memoryStream;
                    try
                    {
                        await _next(context);
                        result = new ApiResponse(
                            success: true,
                            code: context.Response.StatusCode,
                            message: ApiResponse.UserResponseMessage ?? (context.Response.StatusCode >= 300
                                ? ReasonPhrases.GetReasonPhrase(context.Response.StatusCode)
                                : null),
                            data: GetResponseObject(context, memoryStream, currentBody));
                    }
                    catch (Exception ex)
                    {
                        result = new ApiResponse(
                            success: false,
                            code: context.Response.StatusCode,
                            message: $"Unhandled exception: {ex.GetType().Name}, message: {ex.Message}",
                            data: GetResponseObject(context, memoryStream, currentBody));
                    }
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                }
                else
                    await _next(context);
            }
            ApiResponse.UserResponseMessage = null;
        }

        private object GetResponseObject(HttpContext context, MemoryStream memoryStream, Stream currentBody)
        {
            context.Response.Body = currentBody;
            context.Response.ContentType = "application/json; charset=utf-8";
            memoryStream.Seek(0, SeekOrigin.Begin);
            var readToEnd = new StreamReader(memoryStream).ReadToEnd();
            object? deserialized = null;
            try
            {
                deserialized = JsonConvert.DeserializeObject(readToEnd);
            }
            catch (Exception)
            {
                deserialized = new
                {
                    serializationSkipped = true,
                    content = readToEnd
                };
            }
            return deserialized;
        }
    }

    public static class UseApiResponseMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiResponse(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UseApiResponseMiddleware>();
        }
    }
}