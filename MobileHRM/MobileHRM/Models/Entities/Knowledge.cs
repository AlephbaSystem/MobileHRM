using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    public class Knowledge
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string detail { get; set; }

    }
}
