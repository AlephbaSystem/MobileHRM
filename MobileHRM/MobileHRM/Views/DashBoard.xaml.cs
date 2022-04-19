using MobileHRM.Database;
using MobileHRM.Views.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoard : ContentPage
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        private async void OnTabNotification(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                var NotificationFrame = sender as Frame;
                IsBusy = true;
                Animation animation = new Animation(v => NotificationFrame.Scale = v, 0.8, 1.3, Easing.SinInOut);
                animation.Commit(NotificationFrame, "animate", 20, 200, Easing.SinIn);
                await PopupNavigation.Instance.PushAsync(new Views.Popup.Notifications());
                IsBusy = false;
                await NotificationFrame.ScaleTo(1, 200, Easing.SinIn);
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var database = PunchDataBase.Instance.GetAwaiter().GetResult();
            var item = await database.GetLastPunch();
            if (item != null)
            {
                if (item.type == "restIn" || item.type == "PunchIn")
                {
                    (PunchInDetail.Children[0] as Label).Text = "PunchIn";
                    (PunchInDetail.Children[1] as Label).Text = item.date.ToString("HH:mm");
                }
                else
                {
                    (PunchOutDetail.Children[0] as Label).Text = "PunchOut";
                    (PunchOutDetail.Children[1] as Label).Text = item.date.ToString("HH:mm");
                }
            }
        }
        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {

        }

        private async void Punch_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PunchIn());
        }
    }
}