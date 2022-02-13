using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using MobileHRM.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileHRM.Views;

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
                await PopupNavigation.Instance.PushAsync(new Views.Popup.PunchIn());
            }
            IsBusy = false;
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
                await PopupNavigation.Instance.PushAsync(new Views.Popup.Notifications());
            }
            IsBusy = false;
        }
    }
}