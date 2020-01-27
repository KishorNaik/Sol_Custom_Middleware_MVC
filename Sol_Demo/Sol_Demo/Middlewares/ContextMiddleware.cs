using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Sol_Demo.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Items.Add("SecretKey", Guid.NewGuid().ToString());

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseContextMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContextMiddleware>();
        }
    }
}
