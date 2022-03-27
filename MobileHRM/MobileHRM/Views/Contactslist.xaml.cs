using MobileHRM.Models.Entities.Request;
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
    public partial class Contactslist : ContentPage
    {
        ContactsListViewModel vm;
        public Contactslist()
        {
            InitializeComponent();
            vm = new ContactsListViewModel(ref list);
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.initialize();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

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

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var items = (List<Contact>)list.SelectedItems;
            await Navigation.PushAsync(new CreateGroup(items));
        }
    }
}