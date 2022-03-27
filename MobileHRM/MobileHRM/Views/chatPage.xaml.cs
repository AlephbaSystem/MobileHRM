using MobileHRM.Models.Api;
using MobileHRM.ViewModel;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chatPage : ContentPage
    {
        ChatViewModel vm = new ChatViewModel();
        public chatPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loading.IsVisible = loading.IsRunning = true;
            vm.initialize();
            loading.IsVisible = loading.IsRunning = false;
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var i = (TapGestureRecognizer)((Grid)sender).GestureRecognizers[0];
            await Navigation.PushAsync(new MessagePage((Models.Entities.Group)i.CommandParameter));
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popup.Notifications());
        }

        private async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contactslist());
        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {

        }

        private void CustomEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            vm.SearchByMessage(searchBar.Text);
        }
    }
}