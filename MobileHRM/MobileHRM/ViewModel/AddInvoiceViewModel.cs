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
        private int _InvoiceNumber;
        public int InvoiceNumber { get { return _InvoiceNumber; } set { _InvoiceNumber = value; OnPropertyChanged(nameof(InvoiceNumber)); } }
        public AddInvoiceViewModel()
        {
            InvoiceDetail = new Invoice
            {
                attachments = new ObservableCollection<Models.Entities.Attachment>()
            };
            save = new Command(SaveInvoice);
            clear = new Command(clearInvoice);
        }
        private Invoice _InvoiceDetail;
        public Invoice InvoiceDetail
        {
            get
            {
                return _InvoiceDetail ?? new Invoice();
            }
            set
            {
                _InvoiceDetail = value;
                OnPropertyChanged(nameof(InvoiceDetail));
            }
        }
        public async void GetInvoiceNumber()
        {
            InvoiceNumber = await Api.GetInvoiceNumber();
        }

        readonly AccountingApi Api = new AccountingApi();
        private async void SaveInvoice(object sender)
        {
            if (InvoiceDetail.type == 0 || InvoiceDetail.businessId == 0 || InvoiceDetail.attachments == null || InvoiceDetail.attachments.Count == 0)
            {
                //await Application.Current.MainPage.DisplayAlert("Error!","Please Fill All Information \nThen try Again!","Back");
                await new Views.Popup.ShowMsgPopup("Please Fill All Information \nThen try Again!", "Error").ShowAsync();
                return;
            }
            await Api.PostInvoice(InvoiceDetail);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private void clearInvoice(object sender)
        {
            InvoiceDetail = new Invoice
            {
                attachments = new ObservableCollection<Models.Entities.Attachment>()
            };
        }
        public ICommand save { protected set; get; }
        public ICommand clear { protected set; get; }
        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }
    }
}