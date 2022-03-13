using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class GroupMessage
    {
        public int id { get; set; }
        public int messagesGroupId { get; set; }
        public int userId { get; set; }
        public string message { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updateAt { get; set; }
        List<MessageSeen> messageSeens { get; set; }
    }
}
