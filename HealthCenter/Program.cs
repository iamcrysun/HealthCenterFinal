
using DAL;
using DAL.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace HealthCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope()) осталось с лабораторных
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context =
            //        services.GetRequiredService<HealthyContext>();
            //        DbInitializer.Initialize(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger =
            //        services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred creating the DB.");
            //    }
            //}
            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[]
        args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
    }
}