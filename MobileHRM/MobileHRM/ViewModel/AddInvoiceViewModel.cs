using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileHRM.ViewModel
{
    public class AddInvoiceViewModel : Base
    {
        public AddInvoiceViewModel()
        {
            Attachments = new ObservableCollection<byte[]>();
        }
        private ObservableCollection<byte[]> _Attachments;
        public ObservableCollection<byte[]> Attachments
        {
            get
            {
                return _Attachments;
            }
            set
            {
                _Attachments = value;
                OnPropertyChanged(nameof(Attachments));
            }
        }
    }
}
