using MobileHRM.Models.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MobileHRM.Api
{
    public class UserRegisterApi
    {
        string requestUrl = "";
        HttpClient httpClient;
        public UserRegisterApi()
        {
                httpClient = new HttpClient();
        }

        public async System.Threading.Tasks.Task<string> UserRegister(UserRegisterRequest Model)
        {
            string Address1 = requestUrl + "";
            string contentStr = JsonConvert.SerializeObject(Model);
            StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(Address1, content);
            if (response.IsSuccessStatusCode)
            {
                string errorMessage = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return errorMessage;
            }
            else
            {
                return null;
            }
        }
    }
}
