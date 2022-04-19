using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Request
{
    public class VerifyRequest
    {
        //public int userId { get; set; }
        public string phoneNumber { get; set; } = string.Empty;
        public string verifyCode { get; set; } = string.Empty;
    }
}
