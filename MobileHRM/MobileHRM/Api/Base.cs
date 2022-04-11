using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileHRM.Api
{
    public static class Base
    {
        public static async Task<bool> Put(HttpRequestMessage content)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                using (HttpClient request = new HttpClient())
                {
                    request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    response = await request.SendAsync(content);
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
        public static async Task<bool> Post(HttpRequestMessage content)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                using (HttpClient request = new HttpClient())
                {
                    response = await request.PostAsync(content.RequestUri, content.Content);
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
        public static async Task<bool> Delete(string uri)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                using (HttpClient request = new HttpClient())
                {
                    response = await request.DeleteAsync(uri);
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
        public static async Task<string> Get(string uri)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetAsync(uri);
                }
                string content = string.Empty;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    content = await response.Content.ReadAsStringAsync();
                }
                return content ?? "";
            }
            catch (Exception e)
            {
                return "false";
                throw;
            }
        }
    }
}
