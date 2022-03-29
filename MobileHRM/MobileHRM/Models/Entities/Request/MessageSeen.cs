using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities.Request
{
    public class MessageSeen
    {
        public int userId { get; set; }
        public int messageId { get; set; }
    }
}
