﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities.Request
{
    public class comment
    {
        public DateTime createAt { get; set; }
        public string message { get; set; }
        public int KnowledgeId { get; set; }
        public int reactionId { get; set; }
        public bool isLike { get; set; }
        public int userId { get; set; }
    }
}
