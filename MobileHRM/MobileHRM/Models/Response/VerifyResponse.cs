using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Response
{
    public class VerifyResponse
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
