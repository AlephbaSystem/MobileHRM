using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Request
{
    public class VerifyRequest
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string VerifyCode { get; set; } = string.Empty;
    }
}
