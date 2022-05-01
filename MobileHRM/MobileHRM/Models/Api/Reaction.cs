using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class Reaction
    {
        public int knowledgeId { get; set; }
        public int userId { get; set; }
        public bool isLike { get; set; }
    }
}
