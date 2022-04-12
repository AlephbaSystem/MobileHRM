using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MobileHRM.Helper;
using MobileHRM.Models.Request;
using MobileHRM.Models.Response;
using Newtonsoft.Json;

namespace MobileHRM.Api
{
    public class AuthenticationApi
    {
        readonly string requestUri = "http://185.18.214.100:29172/";
        HttpClient httpClient;

        public AuthenticationApi()
        {
            httpClient = new HttpClient();
        }

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
                string url = requestUri + "User/Login";
                string contentStr = JsonConvert.SerializeObject(requestModel);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<VerifyResponse> Validate(VerifyRequest requestModel)
        {
            try
            {
                string url = requestUri + "User/Validate";
                string contentStr = JsonConvert.SerializeObject(requestModel);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    string con = await response.Content.ReadAsStringAsync();
                    VerifyResponse Token = JsonConvert.DeserializeObject<VerifyResponse>(con);
                    return Token;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}
