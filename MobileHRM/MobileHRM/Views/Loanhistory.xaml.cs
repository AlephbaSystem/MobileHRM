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
    public partial class Loanhistory : ContentPage
    {
        public Loanhistory()
        {
            InitializeComponent();
            loan.ItemsSource = nyrg();
            loan.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 20
            };
        }
        public List<temps> nyrg()
        {
            List<temps> list = new List<temps>
            {
                new temps{Name = "Next payment",Name1="4days" },
                new temps{Name = "Next payment",Name1="4days" },
                new temps{Name = "Next payment",Name1="4days" },
                new temps{Name = "Next payment",Name1="4days" },
                new temps{Name = "Next payment",Name1="4days" },
                new temps{Name = "Next payment",Name1="4days" },
                new temps{Name = "Next payment",Name1="4days" },
                new temps{Name = "Next payment",Name1="4days" },
            };
            return list;
        }
    }
    public class temps
    {
        public string Name { get; set; }
        public string Name1 { get; set; }
    }
}