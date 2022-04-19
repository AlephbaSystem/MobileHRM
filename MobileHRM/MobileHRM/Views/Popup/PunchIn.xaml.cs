using MobileHRM.Api;
using MobileHRM.Models.Entities;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.Models.Request;
using MobileHRM.Models;
using MobileHRM.Database;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PunchIn : PopupPage
    {
        public PunchIn()
        {
            InitializeComponent();
            CheckTime();


        }
        private async void OnExitImageButtonClicked(object sender, EventArgs e)
        {
            Animation animation = new Animation(v => ImageExitPunchIn.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(ImageExitPunchIn, "animate", 20, 200, Easing.SinIn);
            await ImageExitPunchIn.ScaleTo(1, 200, Easing.SinIn);
            await PopupNavigation.Instance.PopAsync();
        }
        SummaryApi request = new SummaryApi();
        private async void Punch_Clicked(object sender, EventArgs e)
        {
            var database = PunchDataBase.Instance.GetAwaiter().GetResult();
            await database.InsertPunch(localDatabaseobj);
            await request.InsertPunch(DataObj);
            await PopupNavigation.Instance.PopAsync();
        }
        punchInRequest DataObj;
        Punch localDatabaseobj;
        private async void CheckTime()
        {
            var database = PunchDataBase.Instance.GetAwaiter().GetResult();
            var item = await database.GetLastPunch();
            DataObj = new punchInRequest { type = "PunchOut", comment = CommentEntry.Text, date = DateTime.Now, userId = User.UserId };
            if (item == null)
            {
                DataObj = new punchInRequest { type = "PunchIn", comment = CommentEntry.Text, date = DateTime.Now, userId = User.UserId };
                localDatabaseobj = new Punch { type = "PunchIn", comment = CommentEntry.Text, date = DateTime.Now, userId = User.UserId };
                ImageType.Source = "PunchIn.png";
                TextType.Text = "PunchIn";
                (PunchDetail.Children[0] as Label).Text = $"PunchIn date And Time";
            }
            else if (item.type == "PunchIn" && DateTime.Now.Hour <= 3 && DateTime.Now.Minute < 40)
            {
                DataObj = new punchInRequest { type = "RestOut", comment = CommentEntry.Text, date = DateTime.Now, userId = User.UserId };
                localDatabaseobj = new Punch { type = "RestOut", comment = CommentEntry.Text, date = DateTime.Now, userId = User.UserId };
                ImageType.Source = "PunchOut.png";
                TextType.Text = "PunchOut";
                (PunchDetail.Children[0] as Label).Text = "PuncIn " + "date And Time";
                (PunchDetail.Children[1] as Label).Text = "Today" + $"({item.date.ToString("hh:mm")})";
                (PunchDetail.Children[2] as Label).Text = $"{item.date.ToString("dd-MM-yyyy")}";
            }
            else if (item.type == "RestOut" && DateTime.Now.Hour <= 3 && DateTime.Now.Minute < 40)
            {
                DataObj = new punchInRequest { type = "RestIn", comment = CommentEntry.Text, date = DateTime.Now, userId = User.UserId };
                localDatabaseobj = new Punch { type = "RestIn", comment = CommentEntry.Text, date = DateTime.Now, userId = User.UserId };
                ImageType.Source = "PunchIn.png";
                (PunchDetail.Children[0] as Label).Text = "PunchIn " + "date And Time";
                (PunchDetail.Children[1] as Label).Text = "Today" + $"({item.date.ToString("hh:mm")})";
                (PunchDetail.Children[2] as Label).Text = $"{item.date.ToString("dd-MM-yyyy")}";
            }
            else if ((item.type == "PunchOut" && DateTime.Now.Hour <= 3 && DateTime.Now.Minute < 40))
            {
                IsEnabled = false;
                (PunchDetail.Children[0] as Label).Text = "PuncOut " + "date And Time";
                (PunchDetail.Children[1] as Label).Text = "Today" + $"({item.date.ToString("hh:mm")})";
                (PunchDetail.Children[2] as Label).Text = $"{item.date.ToString("dd-MM-yyyy")}";
            }
            else
            {
                DataObj = new punchInRequest { type = "PunchOut", comment = CommentEntry.Text, date = DateTime.Now, userId = User.UserId };
                localDatabaseobj = new Punch { type = "PunchOut", comment = CommentEntry.Text, date = DateTime.Now, userId = User.UserId };
                ImageType.Source = "PunchOut.png";
                TextType.Text = "PunchOut";
                (PunchDetail.Children[0] as Label).Text = $"PunchOut date And Time";
                (PunchDetail.Children[0] as Label).Text = "PuncOut " + "date And Time";
                (PunchDetail.Children[1] as Label).Text = "Today" + $"({item.date.ToString("hh:mm")})";
                (PunchDetail.Children[2] as Label).Text = $"{item.date.ToString("dd-MM-yyyy")}";
            }
        }
    }
}