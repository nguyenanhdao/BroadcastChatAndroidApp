using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Services
{
    public class UserLoginService : BaseService<UserLoginRequest, UserLoginResponse>
    {
        protected override async Task<UserLoginResponse> DoRunAsync(UserLoginRequest request)
        {
            // Send http post to server to login
            NameValueCollection httpRequest = new NameValueCollection();
            httpRequest["mobile"] = request.Mobile;
            httpRequest["password"] = request.Password;
            UserLoginDTO httpResponse = await HttpHelper.PostAsync<UserLoginDTO>("/api-v1/user/login", httpRequest);
            
            UserLoginResponse response = new UserLoginResponse();
            response.UserLogin = httpResponse;
            return response;
        }
    }
}