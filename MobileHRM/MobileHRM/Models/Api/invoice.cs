using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    internal class invoice
    {
        public int id { get; set; } 
        public int factor { get; set; } 
        public int from { get; set; } 
        public string about { get; set; } 
        public string details { get; set; } 
        public DateTime date { get; set; } 
        public string reciver { get; set; } 
        public decimal amount { get; set; } 
    }
}
