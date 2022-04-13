using MobileHRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class Invoice
    {
        public string from { get; set; }
        public string reciver { get; set; }
        public int businessId { get; set; }
        public DateTime date { get; set; }
        public int type { get; set; } = 0;
        public string details { get; set; }
        public ObservableCollection<Attachment> attachments { get; set; }
        public decimal totality { get; set; } //Business Cost                     
        public decimal amount { get; set; } //SubFactor Amount That User Payed
    }
}