using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Request
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
