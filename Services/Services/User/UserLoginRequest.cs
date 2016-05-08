namespace Services
{
    public class UserLoginRequest : BaseRequest
    {
        public string Mobile { get; set; }

        public string Password { get; set; }
    }
}