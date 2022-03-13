using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class MessageSeen
    {
        public int messagesUsersGroupSeenId { get; set; }
        public int userId { get; set; }
        public int messageId { get; set; }
    }
}