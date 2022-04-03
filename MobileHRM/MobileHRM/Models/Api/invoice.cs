using MobileHRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class Invoice
    {
        public invoice invoiceDetail { get; set; }
        public ObservableCollection<Attachment> attachments { get; set; }
    }
}