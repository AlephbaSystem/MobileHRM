using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MobileHRM.Helper;

namespace MobileHRM.Api
{
    public class AuthenticationApi
    {
        readonly string requestUri = "http://185.18.214.100:29172/";
        HttpClient client = new HttpClient();
        public async Task<bool> TestConnection()
        {
            try
            {
                string url = requestUri + "ServerInfo/TestConnection";
                var TC = await Base.Get(url);
                var CC = JsonDataConverter<bool>.JsonStringToObject(TC);
                return CC;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
