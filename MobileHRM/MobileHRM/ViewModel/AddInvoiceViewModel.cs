using MobileHRM.Api;
using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHRM.ViewModel
{
    public class AddInvoiceViewModel : Base
    {
        public AddInvoiceViewModel()
        {
            InvoiceDetail = new Invoice();
            InvoiceDetail.attachments = new ObservableCollection<Models.Entities.Attachment>();
            save = new Command(SaveInvoice);
            clear = new Command(clearInvoice);
        }
        private Invoice _InvoiceDetail;
        public Invoice InvoiceDetail
        {
            get
            {
                return _InvoiceDetail;
            }
            set
            {
                _InvoiceDetail = value;
                OnPropertyChanged(nameof(InvoiceDetail));
            }
        }
        AccountingApi request = new AccountingApi();
        private async void SaveInvoice(object sender)
        {
            await request.PostInvoice(InvoiceDetail);
        }
        private void clearInvoice(object sender)
        {
            InvoiceDetail = new Invoice();
        }
        public ICommand save { protected set; get; }
        public ICommand clear { protected set; get; }
    }
}