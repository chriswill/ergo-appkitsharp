using System.IO;
using System.Threading.Tasks;
using AppkitSharp.Models.Configuration;
using AppkitSharp.Services.Wallet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

namespace AppkitSharp.TestClient
{
    class Program
    {
        public static IConfiguration Configuration { get; private set; }


        public static async Task Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .Build();

            // configure serilog
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            Log.Information("Starting up...");

            // Create service collection and configure our services
            var services = ConfigureServices();
            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IKeyService, KeyService>();
            
            ErgoNodeConfig nodeConfiguration = new ErgoNodeConfig();
            new ConfigureFromConfigurationOptions<ErgoNodeConfig>(Configuration.GetSection("node"))
                .Configure(nodeConfiguration);
            services.AddSingleton(nodeConfiguration);
            // register the services

            return services;
        }
    }
}
