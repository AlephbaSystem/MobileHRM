using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Request
{
    public class LoginRequest
    {
        public string phoneNumber { get; set; }
        public int appId { get; set; } = 0;
    }
}
