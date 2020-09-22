using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ymb.Infrastructure.Middleware
{
    public class HttpResEncryptMiddleware
    {
        private ILogger<HttpResEncryptMiddleware> _logger;
        private readonly RequestDelegate _next;
        private readonly string securityKey = "";
        private const string GET = "GET";
        private const string POST = "POST";
        private const string PUT = "PUT";
        private const string DELETE = "DELETE";
        public HttpResEncryptMiddleware(RequestDelegate next, ILogger<HttpResEncryptMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }
        public async Task InovkeAsync(HttpContext context)
        {
            if(context.Request.Method.ToUpper() == GET)
            {
                if (context.Request.Path.Value.Contains("/api"))
                {
                    //加密
                    if (context.Response.ContentLength > 0)
                    {

                    }
                }
            }
            await _next(context);
        }
    }
}
