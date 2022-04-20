using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    [Table("UserAutentication")]
    public class UserAutentication
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int userId { get; set; }
        public string token { get; set; }
        public DateTime tokenExpire { get; set; }
        public string userName { get; set; }
    }
}
