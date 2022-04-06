using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    public class invoice
    {
        public int id { get; set; }
        public int businessId { get; set; }
        public int from { get; set; }
        public int type { get; set; }
        public string details { get; set; }
        public DateTime date { get; set; }
        public string reciver { get; set; }
        public decimal totality { get; set; }
    }
}