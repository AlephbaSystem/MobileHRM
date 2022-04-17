using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileHRM.Models.Api
{
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public byte[] image { get; set; }
        public int ownerId { get; set; }
        public string lastMessage { get; set; }
        public DateTime? lastMessageTime { get; set; }
        public int unSeenedMessages { get; set; }
    }
}
