using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileHRM.Models.Entities
{
    public class AccountingOverView
    {
        public string Year { get; set; }
        public decimal  Spent { get; set; }
        public int Balance { get; set; }
        public ObservableCollection<Accounting> Months { get; set; }
    }
    public class Accounting
    {
        public string Month { get; set; }
        public decimal Spent { get; set; }
        public int Balance { get; set; }
    }

}
