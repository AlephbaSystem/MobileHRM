using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    public class Attachment
    {
        public string mediaType { get; set; }
        public byte[] media { get; set; }        
    }
}