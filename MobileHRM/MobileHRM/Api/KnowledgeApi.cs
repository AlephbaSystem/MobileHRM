using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHRM.Models.Api;
using MobileHRM.Helper;
using System.Net.Http;

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
                jsondata = jsondata ?? "";
                List<KnowledgeDetail> items = JsonDataConverter<KnowledgeDetail[]>.JsonStringToObject(jsondata).ToList();
                return items;
            }
            catch (Exception e)
            {
                return new List<KnowledgeDetail>();
                throw;
            }
        }
        public async Task<bool> PostKnowledge(PostKnoweldgeDetail item)
        {
            try
            {
                string url = requestUri + "insertKnowledge";
                string jsnoStr = JsonDataConverter<PostKnoweldgeDetail>.ObjectToJsonString(item);
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
                jsondata = jsondata ?? "";
                List<KnowledgeDetail> items = JsonDataConverter<KnowledgeDetail[]>.JsonStringToObject(jsondata).ToList();
                return items;
            }
            catch (Exception e)
            {
                return new List<KnowledgeDetail>();
                throw;
            }
        }
        public async Task<List<Comment>> GetCommentsByKnowledgeId(int KnowledgeId)
        {
            try
            {
                string uri = requestUri + $"GetCommentsByKnowledgeId?knowledgeId={KnowledgeId}";
                string jsondata = await Base.Get(uri);
                jsondata = jsondata ?? "";
                List<Comment> items = JsonDataConverter<Comment[]>.JsonStringToObject(jsondata).ToList();
                return items;
            }
            catch (Exception e)
            {
                return new List<Comment>();
                throw;
            }
        }
    }
}
