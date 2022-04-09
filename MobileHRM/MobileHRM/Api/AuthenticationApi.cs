using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileHRM.Helper;
using MobileHRM.Models.Request;

namespace MobileHRM.Api
{
    public class AuthenticationApi
    {
        readonly string requestUri = "http://185.18.214.100:29172/";
        //HttpClient client = new HttpClient();
        public async Task<bool> TestConnection()
        {
            try
            {
                string url = requestUri + "ServerInfo/TestConnection";
                var TC = await Base.Get(url);
                //var CC = JsonDataConverter<bool>.JsonStringToObject(TC);

                return bool.Parse(TC);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> Login(LoginRequest requestModel)
        {
            try
            {
                string url = requestUri + "/User/Login";
                string contentStr = JsonDataConverter<LoginRequest>.ObjectToJsonString(requestModel);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = content,
                };

                return await Base.Post(request);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> Validate(VerifyRequest requestModel)
        {
            try
            {
                string url = requestUri + "/User/Validate";
                string contentStr = JsonDataConverter<VerifyRequest>.ObjectToJsonString(requestModel);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = content,
                };
                return await Base.Post(request);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
