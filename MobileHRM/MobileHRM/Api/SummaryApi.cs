using MobileHRM.Helper;
using MobileHRM.Models.Entities;
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
        string requestUri = "http://185.18.214.100:29176/api/Summary";
        HttpClient Client = new HttpClient();


        public async Task<bool> InsertPunch(punchInRequest Saitama)
        {
            try
            {
                string url = requestUri + "InsertPunch";
                string contentStr = JsonConvert.SerializeObject(Saitama);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Content = content,
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url)
                };

                return await Base.Post(request);

            }
            catch (Exception e)
            {
                return false;

            }
        }


        public async Task<List<Punch>> GetPunchByUserId(int userId)
        {
            try
            {
                string url = requestUri + $"GetPunchByUserId?userId{userId}";
                string contentStr = JsonConvert.SerializeObject(userId);
                string ContenStr = await Base.Get(url);
                var items = JsonDataConverter<List<Punch>>.JsonStringToObject(contentStr);
                return items;
            }
            catch (Exception e)
            {
                return new List<Punch>();
            }
        }





    }





}
