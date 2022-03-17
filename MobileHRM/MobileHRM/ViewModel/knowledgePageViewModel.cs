using System;
using System.Collections.Generic;
using System.Text;
using MobileHRM.Models.Api;
using MobileHRM.Api;
using System.Windows.Input;
using Xamarin.Forms;
using MobileHRM.Models;

namespace MobileHRM.ViewModel
{
    class knowledgePageViewModel : Base
    {
        public knowledgePageViewModel(KnowledgeDetail knowledge)
        {
            Item = knowledge;
            SendReaction = new Command(insertReaction);
        }
        private KnowledgeDetail _item;
        public KnowledgeDetail Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }
        private List<Comment> _comments;
        public List<Comment> Comments
        {
            get
            {
                return _comments;
            }
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
        KnowledgeApi request = new KnowledgeApi();
        public async void initialize()
        {
            var i = await request.GetCommentsByKnowledgeId(Item.id);
            Comments = i ?? new List<Comment>();
        }
        private async void insertReaction(object sender)
        {
            var param = (Comment)sender;
            bool res = await request.SendReaction(new Reaction() { commentId = param.commentId, isLike = !param.isLike, userId = User.UserId });
            if (res)
            {
                initialize();
            }
        }
        public ICommand SendReaction { get; protected set; }
    }
}
