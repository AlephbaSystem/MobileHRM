using MobileHRM.Api;
using MobileHRM.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        int knowledgeid;
        public KnowledgeCommentsPopup(int _knowledgeId)
        {
            InitializeComponent();
            knowledgeid = _knowledgeId;
        }
        KnowledgeApi request = new KnowledgeApi();
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var comment = new Models.Api.AddComment { createAt = (DateTime.Now), knowledgeId = knowledgeid, message = commentmessage.Text ?? "", userID = User.UserId, };
            bool res = await request.PostComment(comment);
            await Task.Delay(500);
            await PopupNavigation.Instance.PopAsync();
        }
    }
}