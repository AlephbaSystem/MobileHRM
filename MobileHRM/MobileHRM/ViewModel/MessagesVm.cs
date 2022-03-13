using MobileHRM.Api;
using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.ViewModel
{
    public class MessagesVm : Base
    {
        private int GroupId;
        public MessagesVm(int _GroupId)
        {
            GroupId = _GroupId;
        }
        private List<GroupMessage> _items;
        public List<GroupMessage> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = Items;
                OnPropertyChanged(nameof(Items));
            }
        }
        ChatpAPi request = new ChatpAPi();
        public async void intialize()
        {
            try
            {
                Items = await request.GetMessageByGroupId(GroupId, 0, 20);
            }
            catch (Exception e)
            {
                Items = new List<GroupMessage>();
                throw;
            }
        }
        public async void sendMessage(Message msg)
        {
            await request.SendMessage(msg);
        }
    }
}
