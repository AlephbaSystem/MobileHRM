using System;
using System.Collections.Generic;
using System.Text;
using MobileHRM.Models.Api;
using MobileHRM.Api;
using System.Windows.Input;
using Xamarin.Forms;
using MobileHRM.Models;
using System.Linq;
using MobileHRM.Models.Response;

namespace MobileHRM.ViewModel
{
    class KnowledgePageViewModel : Base
    {
        public KnowledgePageViewModel(KnowledgeDetail knowledge)
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

        private List<RKnowledge> _items;
        public List<RKnowledge> Items
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
            //List<RKnowledge> item = await request.getReactionsByKnowledgeId(knowledgeID, User.UserId);
            //Items = item ?? new List<RKnowledge>();
            //RKnowledge param = Items.FirstOrDefault(p => p.KnowledgeId == knowledgeID);
            layout.BackgroundColor = Color.FromHex("#abcccccc");
            layout.IsEnabled = false;
            //bool res = false;
            //if (param.reactionId == 0)
            //{
            bool res = await request.Knowledge_InsertReaction(new Reaction() { knowledgeId = knowledgeID, isLike = true, userId = User.UserId });
            //}
            //else
            //{
            //    res = await request.UpdateReaction(new Models.Entities.Request.Reaction { reactionId = param.reactionId, knowledgeId = param.KnowledgeId, isLike = !param.isLike, userId = User.UserId });
            //}
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
            //List<RKnowledge> item = await request.getReactionsByKnowledgeId(knowledgeID,User.UserId);
            //Items = item ?? new List<RKnowledge>();
            //RKnowledge param = Items.Where(p => p.KnowledgeId == knowledgeID).FirstOrDefault();
            layout.BackgroundColor = Color.FromHex("#abcccccc");
            layout.IsEnabled = false;
            //bool res = false;
            //if (param.reactionId == 0)
            //{
            bool res = await request.SendReaction(new Reaction() { knowledgeId = knowledgeID, isLike = false, userId = User.UserId });
            //}
            //else
            //{
            //    res = await request.UpdateReaction(new Models.Entities.Request.Reaction { reactionId = param.reactionId, knowledgeId = param.KnowledgeId, isLike = !param.isLike, userId = User.UserId });
            //}
            if (res)
            {
                initialize();
            }
        }
        public ICommand Smile { get; protected set; }
        public ICommand Frown { get; protected set; }
    }
}