using MobileHRM.Models;
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
            initialize(User.UserId);
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
        public void RefreshItems(object sender)
        {
            initialize(User.UserId);
            Isrefreshing = false;
        }
        public async void initialize(int userId)
        {
            try
            {
                Api.ChatApi api = new Api.ChatApi();
                Items = await api.GetGroupsByUserd(userId);
            }
            catch (Exception e)
            {
                _ = e.Message;
                throw;
            }
        } 
        public ICommand refresh { get; protected set; }
    }
}