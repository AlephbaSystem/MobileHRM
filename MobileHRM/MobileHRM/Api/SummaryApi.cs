using MobileHRM.Models.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileHRM.Api
{
    internal class SummaryApi
    {
        string requestUri = "http://185.18.214.100:29176/";
        HttpClient Client = new HttpClient();


        public async Task<bool> InsertPunch(punchInRequest Saitama)
        {
            try
            {
                string url = requestUri + "Summary/InsertPunch";
                string contentStr = JsonConvert.SerializeObject(Saitama);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await Client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                return false;
                
            }
        }


        public async Task<bool> GetPunchByUserId(int userId)
        {
            try
            {
                string url = requestUri + "Summary/GetPunchByUserId";
                string contentStr = JsonConvert.SerializeObject(userId);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await Client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                return false;

            }
        }





    }





}
