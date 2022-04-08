using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    public class Media
    {
        public int id { get; set; }
        public byte[] media { get; set; }
        public string mediaType { get; set; }
    }
}