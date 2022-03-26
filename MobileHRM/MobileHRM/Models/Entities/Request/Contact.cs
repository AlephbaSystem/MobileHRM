using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileHRM.Models.Entities.Request
{
    public class Contact
    {
        public int userId { get; set; }
        public ImageSource image{ get; set; }
        public string userName { get; set; }
    }
}