using MobileHRM.Models.Entities.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class PostKnoweldgeDetail
    {
        public int userId { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public List<reference> references { get; set; }
        public List<tag> tags { get; set; }
    }
}
