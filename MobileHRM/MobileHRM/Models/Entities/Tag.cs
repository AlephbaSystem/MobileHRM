using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    public class Tag
    {
        public int tagId { get; set; }
        public int knowledgeId { get; set; }
        public string tagName { get; set; }
        public string color { get; set; }
    }
}
