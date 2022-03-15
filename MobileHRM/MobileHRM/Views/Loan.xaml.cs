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
    public partial class Loan : ContentPage
    {
        ViewModel.LoanViewModel vm = new ViewModel.LoanViewModel();
        public Loan()
        {
            InitializeComponent();
            BindingContext = vm;
            vm.LoandNextPay = "1";
            vm.NextLoanAmount = "1000";
            vm.Chance = "20";
            vm.RiyalinThebox="10000";
            vm.Participant = "10";


        }
    }
}