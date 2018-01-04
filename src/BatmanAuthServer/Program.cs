// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace QuickstartIdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.File("ha_authdebug.log")
            .CreateLogger();

            Console.Title = "IdentityServer";

            Log.Information("Starting web host: HA Auth");

            //var host = new WebHostBuilder()
            //.UseUrls("http://localhost:5000/auth/")
            //.UseKestrel()
            //.UseSerilog()
            //.UseStartup<Startup>()
            //.Build();

            BuildWebHost(args).Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
                 WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .UseSerilog()
                    .Build();
    }
}
