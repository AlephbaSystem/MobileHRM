using MobileHRM.Helper;
using MobileHRM.Models;
using MobileHRM.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHRM.ViewModel
{
    public class ChatViewModel : Base
    {
        public ChatViewModel()
        {
            Refresh = new Command(RefreshItems);
        }

        private ObservableCollection<GroupModel> _items;
        public ObservableCollection<GroupModel> Items
        {
            get
            {
                if (_items == null)
                {
                    return new ObservableCollection<GroupModel>();
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
        public async void RefreshItems(object sender)
        {
            await Initialize();
            Isrefreshing = false;
        }
        private readonly Api.ChatApi api = new Api.ChatApi();
        private bool IsBusy = false;

        public async Task Initialize()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    Items = new ObservableCollection<GroupModel>();
                    var items = await api.GetGroupsByUserd(User.UserId);
                    foreach (Models.Api.Group item in items)
                    {
                        if (item.lastMessage == null)
                        {
                            item.lastMessage = null;
                        }
                        Items.Add(new GroupModel
                        {
                            id = item.id,
                            name = item.name,
                            ownerId = item.ownerId,
                            unSeenedMessages = item.unSeenedMessages,
                            image = DataConverter.ByteToImage(item.image),
                            lastMessageTime = item.lastMessageTime,
                            lastMessage = item.lastMessage ?? "Nothing to show here",
                        });

                    }
                    Items = Items;
                    IsBusy = false;
                }
                catch (Exception e)
                {
                    _ = e.Message;
                    throw;
                }
            }
        }

        public async Task SearchByMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                await Initialize();
                return;
            }
            var items = await api.GetAllChatsByMessage(message,User.UserId);
            Items = new ObservableCollection<GroupModel>();
            foreach (Models.Api.Group item in items)
            {
                Items.Add(new GroupModel
                {
                    id = item.id,
                    name = item.name,
                    lastMessage = item.lastMessage,
                    lastMessageTime = item.lastMessageTime,
                    unSeenedMessages = item.unSeenedMessages,
                    image = DataConverter.ByteToImage(item.image),
                });
            }
            Items = Items;
        }
        public ICommand Refresh { get; protected set; }
    }
}