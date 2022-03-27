using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class UserProfile
    {
        public int userId { get; set; }
        public byte[] image { get; set; }
        public string userName { get; set; }
    }
}