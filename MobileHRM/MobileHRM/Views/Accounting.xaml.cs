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

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Balance.Text = $"Balance: {await request.GetBalance()} Riyal";
        }

        private async void Balance_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
            }
            IsBusy = false;
        }

        private async void AddInvoice_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new AddInvoice());
            }
            IsBusy = false;
        }

        private async void Report_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Navigation.PushAsync(new Accounting_Report());
            }
            IsBusy = false;
        }

        private async void Business_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;

                await Navigation.PushAsync(new AccountingAddBusiness());
            }
            IsBusy = false;
        }
        private async void Categories_Tapped(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;;
                await Navigation.PushAsync(new AccountingAddBusiness());
            }
            IsBusy = false;
        }


        private void ImageButton_Clicked(object sender, EventArgs e)
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

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }

        AccountingApi request;
        private async void Refresh_Tapped(object sender, EventArgs e)
        {
            IsBusy = true;
            var res = await request.GetBalance();
            if (res==-1)
            {
                Balance.Text = "Sorry \nFailed To Load Balance Try Again Later! ";
            }
            Balance.Text = $"Balance: {res} Riyal";
            IsBusy = false;
        }
        public async void Animate(View label)
        {
            await label.ScaleTo(0.8, 0);
            await label.ScaleTo(1.2, 100, Easing.SpringOut);
            await label.ScaleTo(1, 100, Easing.SpringIn);
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {

        }
    }
}