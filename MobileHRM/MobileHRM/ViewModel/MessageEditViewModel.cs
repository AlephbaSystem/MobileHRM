using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.ViewModel
{
    public class MessageEditViewModel : Base
    {

        public MessageEditViewModel()
        {
            if (messageEdit == null) messageEdit = MessageEditModel.init();
            if (GroupName==null)
            {
                GroupName = MessageEditModel2.init().GroupName;
            }
        }

        private List<MessageEditModel> messageEdit;

        public List<MessageEditModel> MessageEdit
        {
            get { return messageEdit; }
            set
            {
                messageEdit = value;
                OnPropertyChanged(nameof(MessageEdit));
            }
        }

        private string groupName;

        public string GroupName
        {
            get { return groupName; }
            set
            {
                groupName = value;
                OnPropertyChanged(nameof(groupName));
            }
        }


    }
}
