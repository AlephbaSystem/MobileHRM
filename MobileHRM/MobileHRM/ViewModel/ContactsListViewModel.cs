﻿using MobileHRM.Api;
using MobileHRM.Helper;
using MobileHRM.Models;
using MobileHRM.Models.Api;
using MobileHRM.Models.Entities.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileHRM.ViewModel
{
    public class ContactsListViewModel : Base
    {
        StackLayout _list;
        public ContactsListViewModel(ref StackLayout list)
        {
            _list = list;
        }
        private ObservableCollection<Contact> _user;
        public ObservableCollection<Contact> user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(user));
            }
        }
        ChatApi request = new ChatApi();
        public async Task initialize()
        {
            var items = await request.GetContacts();
            ByteToImage(items);
        }
        private void ByteToImage(List<UserProfile> items)
        {
            user = new ObservableCollection<Contact>();
            for (int i = 0; i < items.Count; i++)
            {
                var item = new Contact { userId = items[i].userId, userName = items[i].userName };
                if (items[i].image != null)
                {
                    item.image = DataConverter.ByteToImage(items[i].image);
                }
                user.Add(item);
            }
            user = user;
            AllUsers = user;
            _ = _list;
        }
        private ObservableCollection<Contact> AllUsers = new ObservableCollection<Contact>();
        public void SearchUserByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                user = AllUsers;
            }
            else
            {
                var itms = AllUsers.Where(itm => itm.userName.ToLower().Contains(name.ToLower())).ToList();
                user = new ObservableCollection<Contact>(itms);
            }
        }
    }
}