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
    public partial class AccountingAddBusiness : ContentPage
    {
        AddBusinessViewModel Vm;
        public AccountingAddBusiness()
        {
            InitializeComponent();
            Vm = new AddBusinessViewModel();
            BindingContext = Vm;
        }
    }
}