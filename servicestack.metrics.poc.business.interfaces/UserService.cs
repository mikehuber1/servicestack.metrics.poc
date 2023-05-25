using ServiceStack;

namespace servicestack.metrics.poc.business.interfaces;

public class UserService : Service
{
    public IUserManager UserManager { get; set; }

    public object Get(GetUserInfoRequest request)
    {
        return new GetUserInfoResponse()
        {
            Firstname = UserManager.GetUserInfo(request.Username)
        };
    }
}

public class GetUserInfoRequest : IGet, IReturn<GetUserInfoResponse>
{
    public string Username { get; set; } = "";
}

public class GetUserInfoResponse
{
    public string Firstname { get; set; } = "";
}