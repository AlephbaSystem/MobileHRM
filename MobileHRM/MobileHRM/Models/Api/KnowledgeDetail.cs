using System;
using System.Collections.Generic;
using System.Text;
using MobileHRM.Models.Entities;

namespace MobileHRM.Models.Api
{
    public class KnowledgeDetail
    {
        public Knowledge knowledge { get; set; }
        public List<Tag> tags { get; set; }
        public Reference reference { get; set; }
    }
}