using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.ViewModel;
using MobileHRM.Models.Api;
using Rg.Plugins.Popup.Services;
using System.Windows.Input;
using Xamarin.Forms.Extended;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Knowledge : ContentPage
    {
        readonly KnowledgeViewModel vm;


        public Knowledge()
        {
            InitializeComponent();
            Describtion.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 15
            };
            vm = new KnowledgeViewModel();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
              {
                  await vm.initialize();
              });
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                TapGestureRecognizer i = (TapGestureRecognizer)((Frame)sender).GestureRecognizers[0];
                await Navigation.PushAsync(new KnowledgePage((KnowledgeDetail)i.CommandParameter));
            });
        }

        private void ImageButton_User(object sender, EventArgs e)
        {

        }

        private async void OnTabNotification(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new Popup.Notifications());
            });
        }

        private async void OnNewFrameClicked(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Navigation.PushAsync(new KnowledgeNew());
            });
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<KnowledgeDetail> searchResult = vm.Items.Where(a => a.title.Contains(searchBar.Text));
            Describtion.ItemsSource = searchResult;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {

        }

        private  async void Nextpage_Clicked(object sender, EventArgs e)
        {
            if (vm.Items.Count == 20) vm.NumberPage++;
            await vm.initialize();
            
        }
    }
}