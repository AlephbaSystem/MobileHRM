using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using MobileHRM.Helper;
using MobileHRM.Models.Api;
using System.Threading.Tasks;
using System.Net.Mime;

namespace MobileHRM.Api
{
    class ChatpAPi
    {
        string requestUri = "http://185.18.214.100:29174/api/Message";
        HttpClient Client = new HttpClient();
        public async Task<bool> CreateGroup(Group dataObj)
        {
            try
            {
                string url = string.Format(requestUri, "/CreteGroup");
                string contentStr = JsonDataConverter<Group>.ObjectToJsonString(dataObj);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpResponseMessage();
                using (HttpClient request = new HttpClient())
                {
                    response = await request.PostAsync(url, content);
                }
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
        public async Task<List<Group>> GetGroupsByUserd(int userId)
        {
            try
            {
                string url = string.Format(requestUri, "/GetGroupsByUserid");
                string contentStr = JsonDataConverter<int>.ObjectToJsonString(userId);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpResponseMessage response = new HttpResponseMessage();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Content = new StringContent("some json", Encoding.UTF8, "application / json"),
                };
                using (HttpClient client = new HttpClient())
                {
                    response = await client.SendAsync(request);
                }
                response.EnsureSuccessStatusCode();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string jsonStr = await response.Content.ReadAsStringAsync();
                    return JsonDataConverter<List<Group>>.JsonStringToObject(jsonStr);
                }
                return new List<Group>();
            }
            catch (Exception e)
            {
                return new List<Group>();
                throw;
            }
        }
    }
}
