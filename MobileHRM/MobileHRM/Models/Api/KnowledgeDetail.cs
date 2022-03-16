using System;
using System.Collections.Generic;
using System.Text;
using MobileHRM.Models.Entities;

namespace MobileHRM.Models.Api
{
    public class KnowledgeDetail
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public List<Reference> references { get; set; }
        public List<Tag> tags { get; set; }
    }
}