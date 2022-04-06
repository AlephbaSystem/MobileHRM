using MobileHRM.Api;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessPopup : PopupPage
    {
        public BusinessPopup()
        {
            InitializeComponent();
            Api = new AccountingApi();
        }
        AccountingApi Api;
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            BusinessList = await Api.GetAllBussiness();
            BindableLayout.SetItemsSource(BusinessItems, BusinessList);
        }

        public EventHandler eventHandler;
        public List<Models.Entities.Business> BusinessList { get; set; }

        private async void Item_Tapped(object sender, EventArgs e)
        {
            var layout = (Frame)sender;
            var item = ((TapGestureRecognizer)layout.GestureRecognizers[0]).CommandParameter;
            eventHandler?.Invoke(item, e);
            await PopupNavigation.Instance.PopAsync();
        }
    }
}