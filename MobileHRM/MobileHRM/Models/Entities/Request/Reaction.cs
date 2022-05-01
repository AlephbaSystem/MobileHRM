using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities.Request
{
    public class Reaction
    {
        public int reactionId { get; set; }
        public int knowledgeId { get; set; }
        public int userId { get; set; }
        public bool isLike { get; set; }
    }
}
