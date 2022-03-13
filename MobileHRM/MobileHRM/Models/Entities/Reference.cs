using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.Models.Entities
{
    public class Reference
    {
        public int referenceId { get; set; }
        public int knowledgeId { get; set; }
        public string referencesName { get; set; }
        public string adress { get; set; }
        public string link { get; set; }
    }
}
