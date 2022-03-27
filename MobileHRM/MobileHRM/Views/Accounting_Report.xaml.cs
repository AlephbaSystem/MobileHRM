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
    public partial class Accounting_Report : TabbedPage
    {
        public Accounting_Report()
        {
            InitializeComponent();
            Children.Add(new Accounting_Report_Chart());
            Children.Add(new Accounting_Report_OverView());
        }
    }
}