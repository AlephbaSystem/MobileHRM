using Rg.Plugins.Popup.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;
using MobileHRM.Views;
using Xamarin.CommunityToolkit.UI.Views;
using System.Threading.Tasks;
using MobileHRM.ViewModel;
using MobileHRM.Models;

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
            User.UserId = 1;
            TabPages.TabItems[4].Content = new chatPage();
            TabPages.TabItems.Add(new TabViewItem { Content = new Knowledge() });
            TabPages.TabItems[1].Content = new TasksCalendarPage();
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
            }
        }

        private async void TabViewItem_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
            TabViewItem tabView = (TabViewItem)sender;
            Animation animation = new Animation(v => tabView.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(tabView, "animate", 20, 200, Easing.SinIn);

            await tabView.ScaleTo(1, 200, Easing.SinIn);
        }

        private async void DashboardTabTapped(object sender, TabTappedEventArgs e)
        {
            TabViewItem tabView = (TabViewItem)sender;
            Animation animation = new Animation(v => tabView.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(tabView, "animate", 20, 200, Easing.SinIn);

            await tabView.ScaleTo(1, 200, Easing.SinIn);
            gridHeaderParent.Children.Remove(ImageButtonArrowLeft);
            gridUserHeader.IsVisible = true;
        }

        ImageButton ImageButtonArrowLeft = new ImageButton
        {
            Source = "VectorarrowLeft.png",
            HeightRequest = 25,
            WidthRequest = 25,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Start,
            BackgroundColor = Color.Transparent,
        };

        private async void PageWithBackButton(object sender, TabTappedEventArgs e)
        {
            TabViewItem tabView = (TabViewItem)sender;
            Animation animation = new Animation(v => tabView.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(tabView, "animate", 20, 200, Easing.SinIn);
            await tabView.ScaleTo(1, 200, Easing.SinIn);

            gridUserHeader.IsVisible = false;
            gridHeaderParent.Children.Add(ImageButtonArrowLeft);
        }

        private async void ShowPopupPunchIn(object sender, TabTappedEventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                TabViewItem tabView = (TabViewItem)sender;
                Animation animation = new Animation(v => tabView.Scale = v, 0.8, 1.3, Easing.SinInOut);
                animation.Commit(tabView, "animate", 20, 200, Easing.SinIn);
                await tabView.ScaleTo(1, 200, Easing.SinIn);
                await PopupNavigation.Instance.PushAsync(new Views.Popup.PunchIn());
                IsBusy = false;
            }
        }
    }
}