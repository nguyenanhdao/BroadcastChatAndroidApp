namespace Services
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            InteralServerError = false;
        }

        public bool InteralServerError { get; set; }
    }
}