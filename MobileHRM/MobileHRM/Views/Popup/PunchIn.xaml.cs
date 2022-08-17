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
        SummaryApi request;
        public PunchIn()
        {
            InitializeComponent();
            CheckTime();
            request = new SummaryApi();
        }
        private async void OnExitImageButtonClicked(object sender, EventArgs e)
        {
            Animation animation = new Animation(v => ImageExitPunchIn.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(ImageExitPunchIn, "animate", 20, 100, Easing.SinIn);
            await ImageExitPunchIn.ScaleTo(1, 100, Easing.SinIn);
            await PopupNavigation.Instance.PopAsync();
        }

        
        private async void Punch_Clicked(object sender, EventArgs e)
        {
            PunchDataBase database = PunchDataBase.Instance.GetAwaiter().GetResult();
            await database.InsertPunch(localDatabaseobj);
            await request.InsertPunch(DataObj);
            await PopupNavigation.Instance.PopAsync();

        }

        punchInRequest DataObj;
        Punch localDatabaseobj;

        private async void CheckTime()
        {
            PunchDataBase database = PunchDataBase.Instance.GetAwaiter().GetResult();
            Punch item = await database.GetLastPunch();
            DataObj = new punchInRequest
            {
                type = "PunchOut",
                comment = CommentEntry.Text,
                date = DateTime.Now,
                userId = User.UserId
            };
            if (item == null)
            {
                DataObj = new punchInRequest
                {
                    type = "PunchIn",
                    comment = CommentEntry.Text,
                    date = DateTime.Now,
                    userId = User.UserId
                };
                localDatabaseobj = new Punch
                {
                    type = "PunchIn",
                    comment = CommentEntry.Text,
                    date = DateTime.Now,
                    userId = User.UserId
                };
                ImageType.Source = "PunchIn.png";
                TextType.Text = "Punch In";
                (PunchDetail.Children[0] as Label).Text = $"Punch In date And Time";
            }
            else if (item.type == "PunchIn" && DateTime.Now.Hour <= 15 && DateTime.Now.Minute < 40)
            {
                DataObj = new punchInRequest
                {
                    type = "RestOut",
                    comment = CommentEntry.Text,
                    date = DateTime.Now,
                    userId = User.UserId
                };
                localDatabaseobj = new Punch
                {
                    type = "RestOut",
                    comment = CommentEntry.Text,
                    date = DateTime.Now,
                    userId = User.UserId
                };
                ImageType.Source = "PunchOut.png";
                TextType.Text = "Punch Out";
                (PunchDetail.Children[0] as Label).Text = "Punc In " + "date And Time";
                (PunchDetail.Children[1] as Label).Text = "Today" + $"({item.date:hh:mm})";
                (PunchDetail.Children[2] as Label).Text = $"{item.date:dd-MM-yyyy}";
            }
            else if (item.type == "RestOut" && DateTime.Now.Hour <= 15 && DateTime.Now.Minute < 40)
            {
                DataObj = new punchInRequest
                {
                    type = "RestIn",
                    comment = CommentEntry.Text,
                    date = DateTime.Now,
                    userId = User.UserId
                };
                localDatabaseobj = new Punch
                {
                    type = "RestIn",
                    comment = CommentEntry.Text,
                    date = DateTime.Now,
                    userId = User.UserId
                };
                ImageType.Source = "PunchIn.png";
                (PunchDetail.Children[0] as Label).Text = "Punch In " + "date And Time";
                (PunchDetail.Children[1] as Label).Text = "Today" + $"({item.date:hh:mm})";
                (PunchDetail.Children[2] as Label).Text = $"{item.date:dd-MM-yyyy}";
            }
            else if (item.type == "PunchOut")
            {
                TextType.IsEnabled = false;
                CommentEntry.IsVisible = false;
                PunchNote.Text = "You are Punch Out!";
                ImageType.Source = "PunchOut.png";
                TextType.Text = "Punch Out";
                (PunchDetail.Children[0] as Label).Text = "Punch Out " + "Date And Time";
                (PunchDetail.Children[1] as Label).Text = "Today" + $"({item.date:hh:mm})";
                (PunchDetail.Children[2] as Label).Text = $"{item.date:dd-MM-yyyy}";
            }
            else
            {
                DataObj = new punchInRequest
                {
                    type = "PunchOut",
                    comment = CommentEntry.Text,
                    date = DateTime.Now,
                    userId = User.UserId
                };
                localDatabaseobj = new Punch
                {
                    type = "PunchOut",
                    comment = CommentEntry.Text,
                    date = DateTime.Now,
                    userId = User.UserId
                };
                ImageType.Source = "PunchOut.png";
                TextType.Text = "Punch Out";
                (PunchDetail.Children[0] as Label).Text = $"Punch Out date And Time";
                (PunchDetail.Children[0] as Label).Text = "Punch Out " + "date And Time";
                (PunchDetail.Children[1] as Label).Text = "Today" + $"({item.date:hh:mm})";
                (PunchDetail.Children[2] as Label).Text = $"{item.date:dd-MM-yyyy}";
            }
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            Animation animation = new Animation(v => ImageExitPunchIn.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(ImageExitPunchIn, "animate", 20, 100, Easing.SinIn);
            await ImageExitPunchIn.ScaleTo(1, 100, Easing.SinIn);
            await PopupNavigation.Instance.PopAsync();
        }
    }
}