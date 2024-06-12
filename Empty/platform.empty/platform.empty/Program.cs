using Autofac.Extensions.DependencyInjection;

namespace platform.empty.API
{
    /// <summary>
    /// Start Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Api Main Method
        /// </summary>
        public static void Main(string[] args) 
        { 
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create Host
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureLogging(config =>
                {
                    config.ClearProviders();
                    //config.AddPlatformTraceLogger();
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}