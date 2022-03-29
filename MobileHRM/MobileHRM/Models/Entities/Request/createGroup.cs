using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileHRM.Models.Entities.Request
{
    public class createGroup
    {
        public string name { get; set; }
        public byte[] image { get; set; }
        public int ownerId { get; set; }
        public List<int> users { get; set; } //group members
    }
}