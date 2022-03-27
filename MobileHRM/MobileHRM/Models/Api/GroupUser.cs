using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Api
{
    class GroupUser
    {
        public int groupId { get; set; }
        public List<int> users { get; set; } //group members
    }
}
