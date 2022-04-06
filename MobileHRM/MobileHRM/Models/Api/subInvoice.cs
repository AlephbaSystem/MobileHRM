using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class subInvoice
    {
        public int id { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public int invoiceId { get; set; }
    }
}
