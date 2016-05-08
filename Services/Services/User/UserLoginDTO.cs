using Newtonsoft.Json;

namespace Services
{
    public class UserLoginDTO : HttpBaseResponse
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "isError")]
        public bool IsError { get; set; }
    }
}