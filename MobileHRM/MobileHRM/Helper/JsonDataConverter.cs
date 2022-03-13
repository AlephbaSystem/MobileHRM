using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Helper
{
    public static class JsonDataConverter<T>
    {
        public static string ObjectToJsonString(T Object)
        {
            return JsonConvert.SerializeObject(Object);
        }
        public static T JsonStringToObject(string jsonString)
        {
            var f=JsonConvert.DeserializeObject(jsonString);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}