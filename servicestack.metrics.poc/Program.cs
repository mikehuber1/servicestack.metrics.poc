using ConfigurationSubstitution;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using servicestack.metrics.poc;

public class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables()
            .EnableSubstitutions("${", "}")
            .AddCommandLine(args)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Development;

        var hostBuilder = new WebHostBuilder()
            .UseKestrel()
            .UseConfiguration(config)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .UseEnvironment(environmentName)
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddSerilog();
            })
            .UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://*:5001/");

        hostBuilder.Build().Run();
    }
}