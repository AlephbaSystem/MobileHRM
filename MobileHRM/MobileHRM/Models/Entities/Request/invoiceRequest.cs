using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities.Request
{
    public class invoiceRequest
    {
        public int id { get; set; }
        public int invoiceNumber { get; set; }
        public int businessNumber { get; set; }
        public int from { get; set; }
        public int type { get; set; }
        public string details { get; set; }
        public DateTime date { get; set; }
        public string reciver { get; set; }
        public decimal amount { get; set; }
    }
}
