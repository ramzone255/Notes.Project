using Notes.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notes.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var serviveProvider = scope.ServiceProvider;
                try
                {
                    var context = serviveProvider.GetRequiredService<AuthDbContext>();
                }
                catch (Exception exception)
                {
                    var logger = serviveProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occurrd while app initialization");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
