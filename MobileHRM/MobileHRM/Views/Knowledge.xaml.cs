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

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Knowledge : ContentPage
    {
        KnowledgeViewModel vm = new KnowledgeViewModel();
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
            vm.initialize();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var i = (TapGestureRecognizer)((Frame)sender).GestureRecognizers[0];
            await Navigation.PushAsync(new KnowledgePage((KnowledgeDetail)i.CommandParameter));
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void  ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popup.Notifications());
        }

        private async void OnNewFrameClicked(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Navigation.PushAsync(new KnowledgeNew());
            });
        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}

