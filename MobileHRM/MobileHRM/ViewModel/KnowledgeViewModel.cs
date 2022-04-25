﻿using System;
using System.Collections.Generic;
using System.Text;
using MobileHRM.Models.Api;
using MobileHRM.Api;
using MobileHRM.Helper;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileHRM.ViewModel
{
    public class KnowledgeViewModel : Base
    {


        public KnowledgeViewModel()
        {
        }
        private List<KnowledgeDetail> _items;
        public List<KnowledgeDetail> Items
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
        public bool _isEmpty = true;
        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
            set
            {
                _isEmpty = value;
                OnPropertyChanged(nameof(IsEmpty));
            }
        }
        KnowledgeApi request = new KnowledgeApi();
        public async void initialize()
        {
            Items = await request.GetAllKnowledges(0, 20);
            IsEmpty = !Convert.ToBoolean(Items.Count);
            await Task.Run(async () =>
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    var KnowldgeCommenstUsers = await request.GetUserProfile(Items[i].id);
                    Items[i].commentedUsers = new List<image>();
                    await GetKnowledgeCommentsUser(KnowldgeCommenstUsers, i);
                }
            }
            );
        }
        private Task GetKnowledgeCommentsUser(List<UserProfile> users, int index)
        {
            try
            {
                for (int i = 0; i < users.Count; i++)
                {
                    var userImageSource = DataConverter.ByteToImage(users[i].image);
                    Items[index].commentedUsers.Add(new image { UserImage = userImageSource });
                }
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                _ = e.Message;
                throw;
            }
        }
    }
}
