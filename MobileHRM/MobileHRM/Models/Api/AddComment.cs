using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class AddComment
    {        
        public DateTime createAt { get; set; }
        public string message { get; set; }
        public int knowledgeId { get; set; }
        public int userId { get; set; }
    }
}
