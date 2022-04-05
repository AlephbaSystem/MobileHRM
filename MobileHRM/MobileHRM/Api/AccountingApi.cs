using MobileHRM.Helper;
using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileHRM.Api
{
    public class AccountingApi
    {
        string requestUrl = "http://185.18.214.100:29177/api/Accounting/";
        public async Task<bool> PostInvoice(Invoice invoiceDetail)
        {
            try
            {
                string contentStr = JsonDataConverter<Invoice>.ObjectToJsonString(invoiceDetail);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Content = content,
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(requestUrl + "AddInvoice"),  //Most Be Changed To Api Url
                };

                return await Base.Post(request);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<List<Models.Entities.Business>> GetAllBussiness()
        {
            try
            {
                string Uri = requestUrl + "GetAllBusiness"; //Most Be Changed To Api Url
                string ContentStr = await Base.Get(Uri);
                List<Models.Entities.Business> Items = JsonDataConverter<List<Models.Entities.Business>>.JsonStringToObject(ContentStr);
                return Items ?? new List<Models.Entities.Business>();
            }
            catch (Exception e)
            {
                return new List<Models.Entities.Business>();
                throw;
            }
        }
        public async Task<int> GetInvoiceNumber()
        {
            try
            {
                string Uri = requestUrl + "GetInvoiceNumber"; //Most Be Changed To Api Url
                string ContentStr = await Base.Get(Uri);
                int number = JsonDataConverter<int>.JsonStringToObject(ContentStr);
                return number;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public async Task<bool> PostBusiness(Business business)
        {
            try
            {
                string contentStr = JsonDataConverter<Business>.ObjectToJsonString(business);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Content = content,
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(requestUrl + "AddBussines"),  //Most Be Changed To Api Url
                };

                return await Base.Post(request);
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
        public async Task<int> GetBalance()
        {
            try
            {
                string Uri = requestUrl + ""; //Most Be Changed To Api Url
                string ContentStr = await Base.Get(Uri);
                int balance = JsonDataConverter<int>.JsonStringToObject(ContentStr);
                return balance;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}