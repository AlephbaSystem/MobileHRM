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
        ViewModel.AccountingViewModel vm;
        public Accounting()
        {
            InitializeComponent();
            vm = new ViewModel.AccountingViewModel();
            BindingContext = vm;
            vm.Accounting = "100";
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void AddInvoice_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddInvoice());
        }

        private async void Report_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Accounting_Report());
        }

        private async void Customers_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountingAddCustomer());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}