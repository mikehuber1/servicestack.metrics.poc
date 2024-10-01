using System.Diagnostics;

namespace servicestack.metrics.poc.business;

public class UserManager : IUserManager
{
    private static ActivitySource ActivitySource = new("POC");

    public string GetUserInfo(string username)
    {
        using var activity = ActivitySource.StartActivity("read user store");

        Thread.Sleep(500);

        return "Peter";
    }
}