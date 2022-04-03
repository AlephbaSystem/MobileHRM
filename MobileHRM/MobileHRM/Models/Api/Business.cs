using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class Business
    {
        public string name { get; set; }
        public int employeeId { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int phoneNumber { get; set; }
        public string city { get; set; }
    }
}