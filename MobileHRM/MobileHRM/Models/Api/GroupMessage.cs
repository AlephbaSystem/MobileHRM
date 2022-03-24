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
        public List<MessageSeen> messageSeens { get; set; }
	    public byte[] media { get; set; }
	    public string mediaType { get; set;}
    }
}
