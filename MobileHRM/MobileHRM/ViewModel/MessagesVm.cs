using MobileHRM.Api;
using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MobileHRM.Models;
using System.Linq;
using System.Threading.Tasks;

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
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        ChatpAPi request = new ChatpAPi();
        public async Task intialize()
        {
            try
            {
                var item = await request.GetMessageByGroupId(GroupId, 0, 20);
                Items = item ?? new List<GroupMessage>();
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
        private ObservableCollection<MessageItem> _myMessage { get; set; }
    }

}