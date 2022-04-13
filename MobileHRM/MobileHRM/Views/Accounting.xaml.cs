﻿using MobileHRM.Api;
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
    public partial class Accounting : ContentPage
    {
        public Accounting()
        {
            InitializeComponent();
            request = new AccountingApi();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void AddInvoice_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddInvoice());
        }

        private async void Report_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Accounting_Report());
        }

        private async void Customers_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountingAddBusiness());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        AccountingApi request;
        private async void Refresh_Tapped(object sender, EventArgs e)
        {
            IsBusy = true;
            Balance.Text = $"Balance: {await request.GetBalance()} Riyal";
            IsBusy = false;
        }
        public async void Animate(View label)
        {
            await label.ScaleTo(0.8, 0);
            await label.ScaleTo(1.2, 100, Easing.SpringOut);
            await label.ScaleTo(1, 100, Easing.SpringIn);
        }
    }
}