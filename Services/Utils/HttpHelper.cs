using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class HttpHelper
    {
        public static async Task<HttpBaseResponse> PostAsync<HttpBaseResponse>(string api, NameValueCollection request)
               where HttpBaseResponse : Services.HttpBaseResponse, new ()
        {
            HttpBaseResponse response = new HttpBaseResponse();
            string apiFullPath = ServiceConfiguration.SERVER_BASE_URL + api;

            using (WebClient webClient = new WebClient())
            {
                byte[] responseBytes = await webClient.UploadValuesTaskAsync(apiFullPath, "POST", request);
                string responseString = Encoding.Default.GetString(responseBytes);
                response = JsonConvert.DeserializeObject<HttpBaseResponse>(responseString);
            }

            return response;
        }
    }
}