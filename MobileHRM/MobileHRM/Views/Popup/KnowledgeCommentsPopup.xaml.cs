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
        int knowledgeId;
        public KnowledgeCommentsPopup(int _knowledgeId)
        {
            InitializeComponent();
            knowledgeId = _knowledgeId;
        }
        KnowledgeApi request = new KnowledgeApi();
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var comment = new Models.Entities.Request.comment { createAt = MobileHRM.Helper.PersianDateTimeConverter.DateTimeToPersian(DateTime.Now), KnowledgeId = knowledgeId, message = commentmessage.Text ?? "", userId = User.UserId };
            bool res = await request.PostComment(comment);
            await Task.Delay(500);
            await PopupNavigation.Instance.PopAsync();
        }
    }
}