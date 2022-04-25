using MobileHRM.Models.Entities.Request;
using MobileHRM.ViewModel;
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
            SelectedItems = new List<Contact>();
            vm.initialize();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {

                await PopupNavigation.Instance.PushAsync(new Popup.Notifications());
            });

        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
        
                var layout = (Grid)sender;
                var child = (Frame)((Grid)sender).Children[0];
                var gesture = (TapGestureRecognizer)layout.GestureRecognizers.First();
                if (SelectedItems.Contains((Contact)gesture.CommandParameter))
                {
                    child.CornerRadius = 0;
                    child.BackgroundColor = Color.Transparent;
                    SelectedItems.Remove((Contact)gesture.CommandParameter);
                }
                else
                {
                    child.BackgroundColor = Color.FromHex("7B61FF");
                    child.CornerRadius = 15;
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
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Navigation.PushAsync(new CreateGroup(SelectedItems));
            });
        }
    }
}