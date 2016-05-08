using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService<BaseRequest, BaseResponse>
        where BaseRequest: Services.BaseRequest
        where BaseResponse : Services.BaseResponse, new ()
    {
        /// <summary>
        /// Run service asynchornous
        /// </summary>
        /// <param name="request">Service request</param>
        /// <returns>Return service response</returns>
        public async Task<BaseResponse> RunAsync(BaseRequest request)
        {
            BaseResponse response = null;

            try
            {
                response = await DoRunAsync(request);
            }
            catch (Exception exc)
            {
                // TO-DO
                // Log exception message and send back to server here
                response = new BaseResponse();
                response.InteralServerError = true;
            }

            return response;
        }

        /// <summary>
        /// Main function of BaseServices. Need to override this
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual Task<BaseResponse> DoRunAsync(BaseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}