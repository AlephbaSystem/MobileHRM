using MobileHRM.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileHRM.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accounting : ContentPage
    {
        ViewModel.Base vm;
        public Accounting()
        {
            InitializeComponent();
            vm = new ViewModel.Base();
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
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Navigation.PushAsync(new AddInvoice());
            });
            
        }

        private async void Report_Tapped(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Navigation.PushAsync(new Accounting_Report());
            });
           
        }

        private async void Business_Tapped(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {

                await Navigation.PushAsync(new AccountingAddBusiness());
            });
           
        }
        private async void Categories_Tapped(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {

                await Navigation.PushAsync(new AccountingAddBusiness());
            });
           
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

        private readonly AccountingApi request;
        private async void Refresh_Tapped(object sender, EventArgs e)
        {
            IsBusy = true;
            decimal res = await request.GetBalance();
            if (res == -1)
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

        private void ImageButton_User(object sender, EventArgs e)
        {

        }

        private async void NotificationTapped(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {

                await PopupNavigation.Instance.PushAsync(new Popup.Notifications());
            }); 

        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {

        }
    }
}