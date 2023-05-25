namespace servicestack.metrics.poc.business;

public class UserManager : IUserManager
{
    public string GetUserInfo(string username)
    {
        
        
        
        Thread.Sleep(500);
        return "Peter";
    }
}