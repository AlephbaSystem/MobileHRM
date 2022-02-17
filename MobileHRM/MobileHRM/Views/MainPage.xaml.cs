using Rg.Plugins.Popup.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using MobileHRM.Views;
using Xamarin.CommunityToolkit.UI.Views;

namespace MobileHRM
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            TabPages.TabItems[1].Content = new chatPage();

        }

        private void OnFabTabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {

        }

        private async void PunchInTabGesture(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Animation animation = new Animation(v => PunchInGrid.Scale = v, 0.8, 1.3, Easing.SinInOut);
                animation.Commit(PunchInGrid, "animate", 20, 200, Easing.SinIn);
                await PunchInGrid.ScaleTo(1, 200, Easing.SinIn);
                await PopupNavigation.Instance.PushAsync(new Views.Popup.PunchIn());
                IsBusy = false;

            }
        }

        private void PunchOutTabGesture(object sender, EventArgs e)
        {

        }


        private void TabView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {

        }

        private async void OnTabNotification(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Animation animation = new Animation(v => NotificationFrame.Scale = v, 0.8, 1.3, Easing.SinInOut);
                animation.Commit(NotificationFrame, "animate", 20, 200, Easing.SinIn);
                await PopupNavigation.Instance.PushAsync(new Views.Popup.Notifications());
                IsBusy = false;
                await NotificationFrame.ScaleTo(1, 200, Easing.SinIn);
                //string music;
                // Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{music}.wav");
            }
        }

        private async void TabViewItem_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
            TabViewItem tabView = (TabViewItem)sender;
            Animation animation = new Animation(v => tabView.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(tabView, "animate", 20, 200, Easing.SinIn);

            await tabView.ScaleTo(1, 200, Easing.SinIn);
        }
    }
}