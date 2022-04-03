using MobileHRM.Models.Entities;
using MobileHRM.ViewModel;
using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddInvoiceAttachment : ContentPage
    {
        AddInvoiceViewModel _vm;
        public AddInvoiceAttachment(AddInvoiceViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
        }

        private async void New_Clicked(object sender, EventArgs e)
        {
            var pickedFile = await CrossFilePicker.Current.PickFile(new string[] { "application/pdf" });
            if (pickedFile != null)
            {
                _vm.InvoiceDetail.attachments = _vm.InvoiceDetail.attachments ?? new System.Collections.ObjectModel.ObservableCollection<Attachment>();
                _vm.InvoiceDetail.attachments.Add(new Attachment { media = pickedFile.DataArray, mediaType = "pdf" });
            }
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            _vm.InvoiceDetail.attachments.Clear();
        }

        private async void Done_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}