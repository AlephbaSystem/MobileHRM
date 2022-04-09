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
            vm.GetInvoiceNumber();
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
            ((Label)BusinessGrid.Children[1]).Text = item.name;
            vm.InvoiceDetail.businessId = item.id;
            ((Label)BusinessGrid.Children[0]).Text = item.id.ToString();
        }

        private async void Type_Tapped(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Choose Type: ", "Back", null, "1", "2");
            if (result == "1" || result == "2")
            {
                vm.InvoiceDetail.type = int.Parse(result);
            }
        }
    }
}