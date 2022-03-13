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
    public partial class chatPage : ContentView
    {
        ChatViewModel vm = new ChatViewModel();
        public chatPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var i = (TapGestureRecognizer)((Grid)sender).GestureRecognizers[0];
            await Navigation.PushAsync(new MessagePage((Group)i.CommandParameter));
        }
    }
}