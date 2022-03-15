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
        ViewModel.AccountingViewModel vm = new ViewModel.AccountingViewModel();
        public Accounting()
        {
            InitializeComponent();
            BindingContext = vm;
            vm.Accounting = "100";
         

            

        }
        

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}