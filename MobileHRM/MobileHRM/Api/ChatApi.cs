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
using MobileHRM.Models.Entities.Request;
using MobileHRM.Models.Entities;
using Group = MobileHRM.Models.Api.Group;

namespace MobileHRM.Api
{
    class ChatApi
    {
        string requestUri = ":29174/api/Message/";
        HttpClient Client = new HttpClient();
        public async Task<bool> CreateGroup(createGroup dataObj)
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/CreateGroup";
                string contentStr = JsonDataConverter<createGroup>.ObjectToJsonString(dataObj);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
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
        public async Task<bool> JoinUserToGroup(GroupUser dataObj)
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/joinUsersToGroup";
                string contentStr = JsonDataConverter<GroupUser>.ObjectToJsonString(dataObj);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
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
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/ReciveMessage";
                string contentStr = JsonDataConverter<Message>.ObjectToJsonString(dataObj);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = content
                };

                var status = await Base.Post(request); //if status false message not sended successfully

                return status;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> InsertMessageSeen(List<Models.Entities.Request.MessageSeen> dataObj)
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/InsertMessageSeens";
                string contentStr = JsonDataConverter<List<Models.Entities.Request.MessageSeen>>.ObjectToJsonString(dataObj);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = content
                };

                var status = await Base.Post(request); //if status false message not seened successfully

                return status;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
        public async Task<bool> DeleteGroupByGroupId(int groupId)
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/DeleteGroupByGroupId?groupId={groupId}";
                var status = await Base.Delete(url);
                return status;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> RemoveUserFromGroup(int groupId, int userId)
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/removeUserFromGroup?userId={userId}&groupId={groupId}";
                var status = await Base.Delete(url);
                return status;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> UpdateGroup(GroupUpdate group)
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/UpdateGroup";
                string contentStr = JsonDataConverter<GroupUpdate>.ObjectToJsonString(group);
                StringContent content = new StringContent(contentStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(url),
                    Content = content
                };

                var status = await Base.Put(request); //if status false message not sended successfully

                return status;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<List<Group>> GetGroupsByUserd(int userId)
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/GetGroupsByUserid?userId={userId}";
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
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/GetMessagesByGroupId?Groupid={Groupid}&offset={offset}&pagination={pagination}";

                string jsonStr = await Base.Get(url);
                if (jsonStr == null)
                {
                    return new List<GroupMessage>();
                }
                List<GroupMessage> items = JsonDataConverter<GroupMessage[]>.JsonStringToObject(jsonStr).ToList();
                return items ?? new List<GroupMessage>();
            }
            catch (Exception e)
            {
                _ = e.Message;
                return new List<GroupMessage>();
                throw;
            }
        }
        public async Task<List<UserProfile>> GetContacts()
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/GetallUsers";
                string jsonStr = await Base.Get(url);
                if (jsonStr == null)
                {
                    return new List<UserProfile>();
                }
                List<UserProfile> items = JsonDataConverter<List<UserProfile>>.JsonStringToObject(jsonStr);
                return items;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return new List<UserProfile>();
                throw;
            }
        }
        public async Task<List<UserProfile>> GetGroupUsersByGroupId(int groupId)
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/GetGroupUsersByGroupId?groupId={groupId}";
                string jsonStr = await Base.Get(url);
                if (jsonStr == null)
                {
                    return new List<UserProfile>();
                }
                List<UserProfile> items = JsonDataConverter<List<UserProfile>>.JsonStringToObject(jsonStr);
                return items;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return new List<UserProfile>();
                throw;
            }
        }
        public async Task<List<Group>> GetAllChatsByMessage(string Message,int userId)
        {
            try
            {
                string url = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/GetChatsByMessage?Message={Message}&userId={userId}";
                string jsonStr = await Base.Get(url);
                if (jsonStr == null)
                {
                    return new List<Group>();
                }
                List<Group> items = JsonDataConverter<List<Group>>.JsonStringToObject(jsonStr);
                return items;
            }
            catch (Exception e)
            {
                _ = e.Message;
                return new List<Group>();
                throw;
            }
        }
        public async Task<byte[]> GetMediaByMediaId(int mediaId)
        {
            try
            {
                string uri = $"http://{MobileHRM.Helper.Statics.IP}{requestUri}/GetMediaByMediaId?mediaId={mediaId}";
                string contentStr = await Base.Get(uri);
                var items = JsonDataConverter<byte[]>.JsonStringToObject(contentStr);
                return items ?? new byte[0];
            }
            catch (Exception e)
            {
                return new byte[0];
            }
        }

    }
}