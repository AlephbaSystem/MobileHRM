using MobileHRM.Api;
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
    public partial class Accounting : ContentPage
    {
        public Accounting()
        {
            InitializeComponent();
            request = new AccountingApi();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            loading.IsVisible = loading.IsRunning = true;
            Task.Delay(5000);
            loading.IsVisible = loading.IsRunning = false;
        }

        private async void Balance_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await anime(sender);
            }
            IsBusy = false;
        }

        private async void AddInvoice_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await anime(sender);
                //Frame frm = (Frame)sender;
                //Animation animation = new Animation(v => frm.Scale = v, 0.8, 1.3, Easing.SinInOut);
                //animation.Commit(frm, "animate", 20, 200, Easing.SinIn);
                //await frm.ScaleTo(1, 200, Easing.SinIn);
                //await Navigation.PushAsync(new AddInvoice());
            }
            IsBusy = false;
        }

        private async void Report_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await anime(sender);
                //await Navigation.PushAsync(new Accounting_Report());
            }
            IsBusy = false;
        }

        private async void Business_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await anime(sender);
                //await Navigation.PushAsync(new AccountingAddBusiness());
            }
            IsBusy = false;
        }
        private async void Categories_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await anime(sender);
                //await Navigation.PushAsync(new AccountingAddBusiness());
            }
            IsBusy = false;
        }


        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        async Task anime(object sender)
        {
            Frame frm = (Frame)sender;
            Animation animation = new Animation(v => frm.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(frm, "animate", 20, 200, Easing.SinIn);
            await frm.ScaleTo(1, 200, Easing.SinIn);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }

        AccountingApi request;
        private async void Refresh_Tapped(object sender, EventArgs e)
        {
            IsBusy = true;
            Balance.Text = $"Balance: {await request.GetBalance()} Riyal";
            IsBusy = false;
        }
        public async void Animate(View label)
        {
            await label.ScaleTo(0.8, 0);
            await label.ScaleTo(1.2, 100, Easing.SpringOut);
            await label.ScaleTo(1, 100, Easing.SpringIn);
        }
    }
}