using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MobileHRM.Models;
using System.Linq;

namespace MobileHRM.ViewModel
{
    public class MessagesVm : Base

    {
        public MessagesVm()
        {
            _myMessage = new ObservableCollection<MessageItem>();
        }

        public ObservableCollection<MessageItem> MyMessage
        {
            get
            {
                return _myMessage;
            }
            set
            {
                _myMessage = value;
                OnPropertyChanged(nameof(MyMessage));
            }

        }
        private ObservableCollection<MessageItem> _myMessage { get; set; }
    }

}