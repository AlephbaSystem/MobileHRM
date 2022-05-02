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
    public partial class Tasks : ContentPage
    {
        ViewModel.Base vm;
        public Tasks()
        {
            InitializeComponent();
            vm = new ViewModel.Base();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popup.Notifications());
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_4(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }

        private async void Notification(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new Popup.Notifications());
            });
        }
    }
}