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
            var layout = (Grid)sender;
            var gesture=(TapGestureRecognizer)layout.GestureRecognizers.First();
            if (SelectedItems.Contains((Contact)gesture.CommandParameter))
            {
                layout.BackgroundColor = Color.Transparent;
                SelectedItems.Remove((Contact)gesture.CommandParameter);
            }
            else
            {
                layout.BackgroundColor = Color.FromHex("7B61FF");
                SelectedItems.Add((Contact)gesture.CommandParameter);
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            vm.SearchUserByName(Searchbar.Text);
        }
        private List<Contact> SelectedItems = new List<Contact>();
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateGroup(SelectedItems));
        }
    }
}