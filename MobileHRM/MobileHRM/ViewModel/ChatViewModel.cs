using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
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
            initialize(1);
        }

        private List<Group> _items;
        public List<Group> Items
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
        private void RefreshItems(object sender)
        {
            initialize(1);
            Isrefreshing = false;
        }
        private async void initialize(int userId)
        {
            Api.ChatpAPi api = new Api.ChatpAPi();
            Items = await api.GetGroupsByUserd(userId);
        }
        public ICommand refresh { get; protected set; }
    }
}