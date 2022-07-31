using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    [Table("IpAddress")]
    public class IpAddress
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string ip { get; set; }
    }
}