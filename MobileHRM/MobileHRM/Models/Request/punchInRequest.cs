using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Request
{
    public class punchInRequest
    {
        public int userId { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public string comment { get; set; }
    }
}
