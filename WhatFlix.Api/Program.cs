using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WhatFlix.Api
{
    public class Program
    {
        // public static void Main(string[] args)
        // {
        //     //CreateHostBuilder(args).Build().Run();
        //     WhatFlix.DataAccessLayer.Cache.Seed();

        //     var host = CreateHostBuilder(args).Build();//.Run();
        //     using (var scope = host.Services.CreateScope())
        //     using (var context = scope.ServiceProvider.GetService<MovieContext>())
        //     {
        //         context.Database.EnsureCreated();
        //     }
        //     host.Run();
        // }
        public static void Main(string[] args)
        {
            DataAccessLayer.WhatFlix.Cache.Seed();
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<DataAccessLayer.WhatFlix.MovieContext>())
            {
                context.Database.EnsureCreated();
            }
            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
        // public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Startup>();
        //         });
    }
}
