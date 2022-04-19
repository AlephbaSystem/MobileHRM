using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    [Table("Punch")]
    public class Punch
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public string comment { get; set; }
    }
}