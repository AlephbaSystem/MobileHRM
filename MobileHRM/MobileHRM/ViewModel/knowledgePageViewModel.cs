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
using System.Threading.Tasks;

namespace MobileHRM.ViewModel
{
    class KnowledgePageViewModel : Base
    {
        public KnowledgePageViewModel(KnowledgeDetail knowledge)
        {
            Item = knowledge;
            Smile = new Command(LikeReaction);
            Frown = new Command(DisLikeReaction);
            Task.Run(async () =>
            {
                await Likes();
            });
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

        private responseKnowledge _responseKnowledges;
        public responseKnowledge ResponseKnowledges
        {
            get => _responseKnowledges;
            set
            {
                _responseKnowledges = value;
                OnPropertyChanged(nameof(ResponseKnowledges));
            }
        }


        readonly KnowledgeApi request = new KnowledgeApi();
        public async void initialize()
        {
            List<Comment> c = await request.GetCommentsByKnowledgeId(User.UserId, Item.id);
            Comments = c ?? new List<Comment>();
            await Likes();
        }

        private async Task Likes()
        {
            responseKnowledge q = await request.getReactionsByKnowledgeId(Item.id, User.UserId);
            ResponseKnowledges = q ?? new responseKnowledge();
        }

        private async void LikeReaction(object sender)
        {
            await IsLike(sender, true);
        }
        private async void DisLikeReaction(object sender)
        {
            await IsLike(sender, false);
        }

        private async Task IsLike(object sender, bool islike)
        {
            Frame layout = sender as Frame;
            int knowledgeID = int.Parse(layout.AutomationId);
            bool res = await request.Knowledge_InsertReaction(new Reaction() { knowledgeId = knowledgeID, isLike = islike, userId = User.UserId });
            if (res)
            {
                initialize();
            }
        }

        public ICommand Smile { get; protected set; }
        public ICommand Frown { get; protected set; }
    }
}