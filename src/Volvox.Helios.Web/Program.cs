using System;
using Hangfire;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volvox.Helios.Service;
using Volvox.Helios.Service.DelayedProcessing;

namespace Volvox.Helios.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var delayedServiceProcessor = services.GetRequiredService<IDelayedServiceProcessor<Action<VolvoxHeliosContext>>>();
                RecurringJob.AddOrUpdate(() => delayedServiceProcessor.ProcessAsync(), "*/5 * * * *");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(c => c.AddJsonFile("./metadata.json"))
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                });
        }
    }
}