using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickstartIdentityServer.Quickstart.Middleware
{
    public static class HeaderLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseHeaderLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeaderLoggingMiddleware>();
        }
    }
}
