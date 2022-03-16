using MobileHRM.Api;
using MobileHRM.Models;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnowledgeCommentsPopup : PopupPage
    {
        int knowledgeId;
        public KnowledgeCommentsPopup(int _knowledgeId)
        {
            knowledgeId = _knowledgeId;
            InitializeComponent();
        }
        KnowledgeApi request = new KnowledgeApi();
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var comment = new MobileHRM.Models.Entities.Request.comment { createAt = DateTime.Now, KnowledgeId = knowledgeId, message = messageEditor.Text,userId=User.UserId };
            bool res = await request.PostComment(comment);
        }
    }
}