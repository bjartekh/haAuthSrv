using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickstartIdentityServer.Quickstart.Middleware
{
    public class HeaderLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public HeaderLoggingMiddleware(RequestDelegate next,
                                                ILogger<HeaderLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(FormatRequest(context.Request));
                await _next(context);
        }

    

        private string FormatRequest(HttpRequest request)
        {
            var headers= request.Headers.Select(x => x.Key + " : " + x.Value+" | ").ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("HEADERS >> :");
            foreach(string s in headers)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }
    }
}
