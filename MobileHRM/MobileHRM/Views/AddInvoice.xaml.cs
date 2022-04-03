using MobileHRM.ViewModel;
using MobileHRM.Views.Popup;
using Rg.Plugins.Popup.Services;
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

        private async void Business_Tapped(object sender, EventArgs e)
        {
            var popup = new BusinessPopup();
            popup.eventHandler += Business_Item;
            await PopupNavigation.Instance.PushAsync(popup);
        }
        private void Business_Item(object sender, EventArgs e)
        {
            var item = ((Models.Entities.Business)sender);
            vm.InvoiceDetail.invoiceDetail.invoiceNumber = item.id;
            BusinessName.Text = item.name;
        }
    }
}