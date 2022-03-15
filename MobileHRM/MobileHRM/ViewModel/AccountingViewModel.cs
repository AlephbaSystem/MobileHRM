using MobileHRM.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.ViewModel
{
    public class AccountingViewModel: Base
    {
        private string accounting { get; set; }

        public string Accounting
        {
            get
            {
                return accounting;
            }
            set
            {
                accounting = value;
                OnPropertyChanged(nameof(Accounting));
            }
        }
    }
   
}
