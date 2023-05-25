using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceStack;

namespace servicestack.metrics.poc;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory factory)
    {

        app.UseServiceStack(new AppHost(env.EnvironmentName, Configuration, factory));
    }
}