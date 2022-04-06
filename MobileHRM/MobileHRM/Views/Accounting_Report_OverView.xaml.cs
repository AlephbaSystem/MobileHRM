using MobileHRM.ViewModel;
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
    public partial class Accounting_Report_OverView : ContentPage
    {
        List<AccountingOverViewViewModel> Vm;
        public Accounting_Report_OverView()
        {
            InitializeComponent();
            Vm = new List<AccountingOverViewViewModel>();
            BindingContext = Vm;
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await (sender as Grid).Children[3].RelRotateTo(180, 150);
            var parent = (StackLayout)(sender as Grid).Parent;
            parent.Children[1].IsVisible = !parent.Children[1].IsVisible;
        }
    }
}

