using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MobileClaimJobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                JobsInit.InitiateJobs().GetAwaiter().GetResult();
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred in Main function with the error message : {ex.Message}");
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddEnvironmentVariables();
                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        builder.AddUserSecrets("MobileClaimJobs");
                    }
                })
                .UseStartup<Startup>();
    }
}
