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
        readonly ChatViewModel vm;
        public chatPage()
        {
            InitializeComponent();
            vm = new ChatViewModel();
            BindingContext = vm;            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();            
            loading.IsVisible = loading.IsRunning = true;
            await vm.Initialize();
            loading.IsVisible = loading.IsRunning = false;
        }
        
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                var i = (TapGestureRecognizer)((Grid)sender).GestureRecognizers[0];
                await Navigation.PushAsync(new MessagePage((Models.Entities.GroupModel)i.CommandParameter));
            });
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)

        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new Popup.Notifications());

            });
        }
        private async void ImageButton_Clicked_2(object sender, EventArgs e)
            
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Navigation.PushAsync(new Contactslist());
            });
        }

        private async void ImageButton_Clicked_3(object sender, EventArgs e)
        {

        }
        private async void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            await vm?.RunIsBusyTaskAsync(async () =>
            {
                await vm.SearchByMessage(searchBar.Text);
            });
        }
    }
}