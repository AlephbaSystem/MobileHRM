using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models
{
    public class MessageItem
    {
        public string Text { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public DateTime Time { get; set; }
        public bool IsMessageYours { get; set; }

    }
}