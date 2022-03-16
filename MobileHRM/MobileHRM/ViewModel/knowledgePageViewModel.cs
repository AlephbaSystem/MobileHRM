using System;
using System.Collections.Generic;
using System.Text;
using MobileHRM.Models.Api;
using MobileHRM.Api;

namespace MobileHRM.ViewModel
{
    class knowledgePageViewModel : Base
    {
        public knowledgePageViewModel(KnowledgeDetail knowledge)
        {
            Item = knowledge;

            initialize();
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
        KnowledgeApi request = new KnowledgeApi();
        public async void initialize()
        {
            var i= await request.GetCommentsByKnowledgeId(Item.id);
            Comments = i ?? new List<Comment>();             
        }
    }
}
