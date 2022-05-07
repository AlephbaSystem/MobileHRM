using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHRM.Models.Api;
using MobileHRM.Helper;
using System.Net.Http;
using MobileHRM.Models.Entities.Request;
using Newtonsoft.Json;

namespace MobileHRM.Api
{
    public class KnowledgeApi
    {
        string requestUri = "http://185.18.214.100:29173/api/Knowledge/";
        public async Task<List<KnowledgeDetail>> GetAllKnowledges(int offset, int pagination)
        {
            try
            {
                string uri = requestUri + $"GetAllKnowledges?offset={offset}&pagination={pagination}";
                string jsondata = await Base.Get(uri);
                jsondata ??= "";
                List<KnowledgeDetail> items = JsonDataConverter<KnowledgeDetail[]>.JsonStringToObject(jsondata).ToList();
                items.Reverse();
                return items;
            }
            catch (Exception e)
            {
                return new List<KnowledgeDetail>();
                throw;
            }
        }
        public async Task<bool> PostUserProfile(UserProfile user)
        {
            try
            {
                string url = requestUri + "insertUserProfile";
                string jsnoStr = JsonDataConverter<UserProfile>.ObjectToJsonString(user);
                StringContent content = new StringContent(jsnoStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = content
                };

                return await Base.Post(request);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<List<UserProfile>> GetUserProfile(int knowledgeId)
        {
            try
            {
                string url = requestUri + $"GetKnowledgeCommentsUser?knowledgId={knowledgeId}";
                string jsonstr = await Base.Get(url);
                List<UserProfile> items = JsonDataConverter<UserProfile[]>.JsonStringToObject(jsonstr).ToList();
                return items ?? new List<UserProfile>();
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<bool> PostKnowledge(PostKnoweldgeDetail item)
        {
            try
            {
                string url = requestUri + "insertKnowledge";
                string jsnoStr = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(jsnoStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = content
                };

                return await Base.Post(request);
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        //public async Task<bool> PostKnowledge(PostKnoweldgeDetail item)
        //{
        //    try
        //    {
        //        string url = requestUri + "insertKnowledge";
        //        string jsnoStr = JsonConvert.SerializeObject(item);
        //        StringContent content = new StringContent(jsnoStr, Encoding.UTF8, "application/json");
        //        HttpResponseMessage request = await httpClient.PostAsync(url, content);
        //        return request.IsSuccessStatusCode;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //        throw;
        //    }
        //}


        public async Task<bool> PostComment(AddComment item)
        {
            try
            {
                string url = requestUri + "insertComment";
                string jsnoStr = JsonDataConverter<AddComment>.ObjectToJsonString(item);
                StringContent content = new StringContent(jsnoStr, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = content
                };

                return await Base.Post(request);
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
        public async Task<List<KnowledgeDetail>> GetKnowledgesByTag(string tagName, int offset, int pagination)
        {
            try
            {
                string uri = requestUri + $"GetKnowledgesByTag?tagName={tagName}&offset={offset}&pagination={pagination}";
                string jsondata = await Base.Get(uri);
                jsondata ??= "";
                List<KnowledgeDetail> items = JsonDataConverter<KnowledgeDetail[]>.JsonStringToObject(jsondata).ToList();
                return items;
            }
            catch (Exception e)
            {
                return new List<KnowledgeDetail>();
                throw;
            }
        }
        public async Task<List<Comment>> GetCommentsByKnowledgeId(int userId, int KnowledgeId)
        {
            try
            {
                string uri = requestUri + $"GetCommentsByKnowledgeId?knowledgeId={KnowledgeId}&userId={userId}";
                string jsondata = await Base.Get(uri);
                jsondata ??= "";
                List<Comment> items = JsonDataConverter<Comment[]>.JsonStringToObject(jsondata).ToList();
                return items;
            }
            catch (Exception e)
            {
                return new List<Comment>();
                throw;
            }
        }

        readonly HttpClient httpClient = new HttpClient();
        public async Task<bool> Knowledge_InsertReaction(Models.Api.Reaction item)
        {
            try
            {
                string url = requestUri + "knowledge_InsertReaction";
                var contentStr = JsonConvert.SerializeObject(item);
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

        public async Task<List<KnowledgeDetail>> GetKnowledgeById(int id)
        {
            try
            {
                string url = requestUri + $"GetKnowledgeByID?id={id}";
                string jsondata = await Base.Get(url);
                jsondata ??= "";
                List<KnowledgeDetail> items = JsonDataConverter<KnowledgeDetail[]>.JsonStringToObject(jsondata).ToList();
                return items;
            }
            catch (Exception e)
            {
                return new List<KnowledgeDetail>();
                throw;
            }
        }

        public async Task<List<Models.Response.responseKnowledge>> getReactionsByKnowledgeId(int KnowledgeId, int userId)
        {
            try
            {
                string url = requestUri + $"getReactionsByKnowledgeId?KnowledgeId={KnowledgeId}&userId={userId}";
                string jsondata = await Base.Get(url);
                jsondata ??= "";
                List<Models.Response.responseKnowledge> items = JsonDataConverter<Models.Response.responseKnowledge[]>.JsonStringToObject(jsondata).ToList();
                return items;
            }
            catch (Exception e)
            {
                return new List<Models.Response.responseKnowledge>();
                throw;
            }
        }
    }
}
