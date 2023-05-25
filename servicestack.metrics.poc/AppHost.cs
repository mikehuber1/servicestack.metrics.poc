using Funq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceStack;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using servicestack.metrics.poc.business;
using servicestack.metrics.poc.business.interfaces;
using ServiceStack.NetCore;

namespace servicestack.metrics.poc;

public class AppHost : AppHostBase
{
    public AppHost(string environmentName, IConfiguration configuration, ILoggerFactory factory)
        : base("Metrics.POC", typeof(UserService).Assembly)
    {
        _loggerFactory = factory;
        AppSettings = new MultiAppSettingsBuilder(environmentName)
            .AddNetCore(configuration)
            .AddEnvironmentalVariables()
            .AddAppSettings()
            .Build();
    }


    private readonly ILoggerFactory _loggerFactory;

    public override void Configure(Container container)
    {
        LogManager.LogFactory = new NetCoreLogFactory(_loggerFactory);

        container.RegisterAutoWiredAs<UserManager, IUserManager>().ReusedWithin(ReuseScope.None);
    }
}