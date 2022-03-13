using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class Message
    {
        public int messagesGroupId { get; set; }
        public int userId { get; set; }
        public string message { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updateAt { get; set; }
    }
}
