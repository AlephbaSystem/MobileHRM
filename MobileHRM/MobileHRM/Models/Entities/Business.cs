using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    public class Business
    {
        public int id { get; set; }
        public string name { get; set; }
        public string employeeId { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int phoneNumber { get; set; }
        public string city { get; set; }
    }
}
