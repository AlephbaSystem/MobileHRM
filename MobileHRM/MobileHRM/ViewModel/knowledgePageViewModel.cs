﻿using System;
using System.Collections.Generic;
using System.Text;
using MobileHRM.Models.Api;
using MobileHRM.Api;
using System.Windows.Input;
using Xamarin.Forms;
using MobileHRM.Models;
using System.Linq;

namespace MobileHRM.ViewModel
{
    class knowledgePageViewModel : Base
    {
        public knowledgePageViewModel(KnowledgeDetail knowledge)
        {
            Item = knowledge;
            Smile = new Command(insertReaction);
            Frown = new Command(insertReaction1);
        }

        private KnowledgeDetail _item;

        public KnowledgeDetail Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        private List<KnowledgeDetail> _items;

        public List<KnowledgeDetail> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private List<Comment> _comments;

        public List<Comment> Comments
        {
            get => _comments;
            set
            {
                _comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }

        //private bool _smileEnabled;
        //public bool smileEnabled
        //{
        //    get
        //    {
        //        return _smileEnabled;
        //    }
        //    set
        //    {
        //        _smileEnabled = value;
        //        OnPropertyChanged(nameof(smileEnabled));
        //    }
        //}
        //private bool _frawnEnabled;
        //public bool frawnEnabled
        //{
        //    get
        //    {
        //        return _frawnEnabled;
        //    }
        //    set
        //    {
        //        _frawnEnabled = value;
        //        OnPropertyChanged(nameof(frawnEnabled));
        //    }
        //}
        readonly KnowledgeApi request = new KnowledgeApi();
        public async void initialize()
        {
            List<Comment> c = await request.GetCommentsByKnowledgeId(User.UserId, Item.id);
            Comments = c ?? new List<Comment>();
        }
        private async void insertReaction(object sender)
        {
            Frame layout = sender as Frame;
            TapGestureRecognizer gesture = layout.GestureRecognizers[0] as TapGestureRecognizer;
            int knowledgeID = int.Parse(layout.AutomationId);
            List<KnowledgeDetail> item = await request.GetKnowledgeById(knowledgeID);
            Items = item ?? new List<KnowledgeDetail>();
            KnowledgeDetail param = Items.Where(p => p.id == knowledgeID).FirstOrDefault();
            layout.BackgroundColor = Color.FromHex("#abcccccc");
            layout.IsEnabled = false;
            bool res = false;
            if (param.reactionId == 0)
            {
                res = await request.SendReaction(new Reaction() { knowledgeId = param.id, isLike = true, userId = User.UserId });
            }
            else
            {
                res = await request.UpdateReaction(new Models.Entities.Request.Reaction { reactionId = param.reactionId, knowledgeId = param.id, isLike = !param.isLike, userId = User.UserId });
            }
            if (res)
            {
                initialize();
            }
        }
        private async void insertReaction1(object sender)
        {
            Frame layout = sender as Frame;
            TapGestureRecognizer gesture = layout.GestureRecognizers[0] as TapGestureRecognizer;
            int knowledgeID = int.Parse(layout.AutomationId);
            List<KnowledgeDetail> item = await request.GetKnowledgeById(knowledgeID);
            Items = item ?? new List<KnowledgeDetail>();
            KnowledgeDetail param = Items.Where(p => p.id == knowledgeID).FirstOrDefault();
            layout.BackgroundColor = Color.FromHex("#abcccccc");
            layout.IsEnabled = false;
            bool res = false;
            if (param.reactionId == 0)
            {
                res = await request.SendReaction(new Reaction() { knowledgeId = param.id, isLike = false, userId = User.UserId });
            }
            else
            {
                res = await request.UpdateReaction(new Models.Entities.Request.Reaction { reactionId = param.reactionId, knowledgeId = param.id, isLike = !param.isLike, userId = User.UserId });
            }
            if (res)
            {
                initialize();
            }
        }
        public ICommand Smile { get; protected set; }
        public ICommand Frown { get; protected set; }
    }
}