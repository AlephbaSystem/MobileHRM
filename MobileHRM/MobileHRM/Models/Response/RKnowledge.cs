using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Response
{
    public class RKnowledge
    {
        public int KnowledgeId { get; set; }
        public int reactionId { get; set; }
        public int userId { get; set; }
        public bool isLike { get; set; }
    }
    public class responseKnowledge
    {
        public bool isLike { get; set; }
        public int Number { get; set; }
    }
}
