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
        List<AccountingModel> AccountingModel = new List<AccountingModel>();
        public Accounting_Report_OverView()
        {
            InitializeComponent();
            AccountingModel = new List<AccountingModel>()
            {
                new AccountingModel()
                {
                    Balance = 20000000,
                    Spent = 1234568,
                    Year = "2022",
                    Models=new List<AccountingModel1>()
                    {
                        new AccountingModel1{Balance =100000,Spent=1000000,Month="Feb"},
                        new AccountingModel1{Balance =100000,Spent=1000000,Month="Feb"},
                        new AccountingModel1{Balance =100000,Spent=10000000,Month="Feb"},
                        new AccountingModel1{Balance =100000,Spent=10000000,Month="Feb"},
                        new AccountingModel1{Balance =100000,Spent=10000000,Month="Feb"},
                        new AccountingModel1{Balance =100000,Spent=100000,Month="Feb"},
                        new AccountingModel1{Balance =100000,Spent=1000000,Month="Feb"},
                    }
                }

            };
            listviewContent.ItemsSource = AccountingModel;

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await (sender as Grid).Children[3].RelRotateTo(180,150);
            var parent = (StackLayout)(sender as Grid).Parent;
            parent.Children[1].IsVisible = !parent.Children[1].IsVisible;
        }
    }
    public class AccountingModel
    {
        public string Year { get; set; }
        public int Spent { get; set; }
        public int Balance { get; set; }

        public List<AccountingModel1> Models { get; set; }
    }
    public class AccountingModel1
    {
        public string Month { get; set; }
        public int Spent { get; set; }
        public int Balance { get; set; }


    }
}

