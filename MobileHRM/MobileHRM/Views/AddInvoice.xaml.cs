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
    public partial class AddInvoice : ContentPage
    {
        AddInvoiceViewModel vm;
        public AddInvoice()
        {
            InitializeComponent();
            vm = new AddInvoiceViewModel();
            BindingContext = vm;
        }

        private async void Attachment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddInvoiceAttachment(vm));
        }
    }
}