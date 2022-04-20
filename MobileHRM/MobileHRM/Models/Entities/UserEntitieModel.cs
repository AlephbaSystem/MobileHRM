using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileHRM.Models.Entities
{
    [Table("UserEntitieModel")]
    public class UserEntitieModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int companyId { get; set; }
        public int groupId { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool inactive { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updateAt { get; set; }
    }
}
