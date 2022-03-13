using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using MobileHRM.Helper;
using MobileHRM.Models.Api;
using System.Threading.Tasks;
using System.Net.Mime;
using MobileHRM.Models;
using System.Linq;

namespace MobileHRM.Api
{
    class ChatApi
    {
        string requestUri = "http://185.18.214.100:29174/api/Message/";
        HttpClient Client = new HttpClient();
        public async Task<bool> CreateGroup(Group dataObj)
        {
            try
            {
                string url = requestUri + "/CreteGroup";
                string contentStr = JsonDataConverter<Group>.ObjectToJsonString(dataObj);
                StringContent content = new StringContent(contentStr, Encoding.UTF8);
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = content,
                };

                return await Base.Post(request);
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
        public async Task<bool> SendMessage(Message dataObj)
        {
            try
            {
                string url = requestUri + "ReciveMessage";
                string contentStr = JsonDataConverter<Message>.ObjectToJsonString(dataObj);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = content 
                };
                
                var status=await Base.Post(request); //if status false message not sended successfully

                return status;
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
                string url = requestUri + $"GetGroupsByUserid?userId={userId}";
                string jsonStr = await Base.Get(url);
                if (jsonStr == null)
                {
                    return new List<Group>();
                }
                var items = JsonDataConverter<Group[]>.JsonStringToObject(jsonStr);
                return items.ToList();
            }
            catch (Exception e)
            {
                return new List<Group>();
                throw;
            }
        }
        public async Task<List<Group>> GetUsersByGroupId(int groupId)
        {
            try
            {
                string url = requestUri + $"GetGroupUsersByGroupId?groupId={groupId}";
                string jsonStr = await Base.Get(url);
                if (jsonStr == null)
                {
                    return new List<Group>();
                }
                var items = JsonDataConverter<Group[]>.JsonStringToObject(jsonStr);
                return items.ToList();
            }
            catch (Exception e)
            {
                return new List<Group>();
                throw;
            }
        }
        public async Task<List<GroupMessage>> GetMessageByGroupId(int Groupid, int offset, int pagination)
        {
            try
            {
                string url = requestUri + $"GetMessagesByGroupId?Groupid={Groupid}&offset={offset}&pagination={pagination}";

                string jsonStr = await Base.Get(url);
                if (jsonStr == null)
                {
                    return new List<GroupMessage>();
                }
                var items = JsonDataConverter<GroupMessage[]>.JsonStringToObject(jsonStr).ToList();
                return items;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return new List<GroupMessage>();
                throw;
            }
        }
    }
}