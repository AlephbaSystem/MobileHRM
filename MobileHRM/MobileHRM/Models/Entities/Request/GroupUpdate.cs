using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities.Request
{
    class GroupUpdate
    {
        public int id { get; set; }
        public string name { get; set; }
        public byte[] image { get; set; }
    }
}
