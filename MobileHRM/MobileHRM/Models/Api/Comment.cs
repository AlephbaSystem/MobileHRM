using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class Comment
    {
        public int commentId { get; set; }
        public DateTime createAt { get; set; }
        public string message { get; set; }
        public bool KnowledgeId { get; set; }
        public int reactionId { get; set; }
        public bool isLike { get; set; }
        public int userId { get; set; }
    }
}