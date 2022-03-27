using MobileHRM.Models.Entities.Request;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateGroup : ContentPage
    {
        public CreateGroup(List<Contact> items)
        {
            InitializeComponent();
            UsersList.ItemsSource = items;
        }
    }
}