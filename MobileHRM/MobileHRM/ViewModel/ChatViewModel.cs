using MobileHRM.Helper;
using MobileHRM.Models;
using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHRM.ViewModel
{
    public class ChatViewModel : Base
    {
        public ChatViewModel()
        {
            refresh = new Command(RefreshItems);
        }

        private ObservableCollection<MobileHRM.Models.Entities.Group> _items;
        public ObservableCollection<MobileHRM.Models.Entities.Group> Items
        {
            get
            {
                if (_items == null)
                {
                    return new ObservableCollection<MobileHRM.Models.Entities.Group>();
                }
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        public bool Isrefreshing
        {
            get { return _Isrefreshing; }
            set
            {
                OnPropertyChanged(nameof(Isrefreshing));
                _Isrefreshing = Isrefreshing;
            }
        }
        private bool _Isrefreshing = false;
        public void RefreshItems(object sender)
        {
            initialize();
            Isrefreshing = false;
        }
        Api.ChatApi api = new Api.ChatApi();
        public async void initialize()
        {
            try
            {

                if (!IsBusy)
                {
                    IsBusy = true;
                    Items = new ObservableCollection<Models.Entities.Group>();
                    var items = await api.GetGroupsByUserd(User.UserId);
                    foreach (var item in items)
                    {
                        Items.Add(new Models.Entities.Group { name = item.name, image = DataConverter.ByteToImage(item.image), id = item.id, lastMessage = item.lastMessage ?? "", ownerId = item.ownerId, lastMessageTime = item.lastMessage == null ? new DateTime() : item.lastMessageTime, unSeenedMessages = item.unSeenedMessages });
                    }
                    Items = Items;
                    IsBusy = false;
                }
            }
            catch (Exception e)
            {
                _ = e.Message;
                throw;
            }
        }
        private bool IsBusy { get; set; } = false;
        public async void SearchByMessage(string message)
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            if (string.IsNullOrEmpty(message))
            {
                initialize();
                return;
            }
            var items = await api.GetAllChatsByMessage(message);
            Items = new ObservableCollection<Models.Entities.Group>();
            foreach (var item in items)
            {
                Items.Add(new Models.Entities.Group { name = item.name, image = DataConverter.ByteToImage(item.image), id = item.id, lastMessage = item.lastMessage, lastMessageTime = item.lastMessageTime, unSeenedMessages = item.unSeenedMessages });
            }
            Items = Items;
            IsBusy = false;
        }
        public ICommand refresh { get; protected set; }
    }
}