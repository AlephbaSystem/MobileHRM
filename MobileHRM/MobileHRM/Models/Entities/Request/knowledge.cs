using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities.Request
{
    public class knowledge
    {
        public int userId { get; set; }
        public string title { get; set; } = string.Empty;
        public string detail { get; set; } = string.Empty;
    }
}
