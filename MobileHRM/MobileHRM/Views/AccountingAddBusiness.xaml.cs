﻿using MobileHRM.ViewModel;
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
    public partial class AccountingAddBusiness : ContentPage
    {
        private readonly AddBusinessViewModel Vm;
        public AccountingAddBusiness()
        {
            InitializeComponent();
            Vm = new AddBusinessViewModel();
            BindingContext = Vm;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private async void City_Tapped(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Choose City: ", "Back", null, new string[] { "Mashhad", "Tehran", "Neishabor", "Esfahan", "Yazd" });
            if (result != "Back")
            {
                Vm.business.city = result;
                Vm.business = Vm.business;
            }
        }
    }
}