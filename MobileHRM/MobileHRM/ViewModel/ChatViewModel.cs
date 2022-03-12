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
                OnPropertyChanged(nameof(Items));
                _items = value;
            }
        }
        private void RefreshItems(object sender)
        {
            initialize(4);
        }
        private async void initialize(int userId)
        {
            Api.ChatpAPi api = new Api.ChatpAPi();
            Items = await api.GetGroupsByUserd(userId);
        }
        public ICommand refresh { get; protected set; }
    }
}