using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.Models.Api;
using MobileHRM.ViewModel;
using MobileHRM.Models.Entities;
using Rg.Plugins.Popup.Services;
using MobileHRM.Views.Popup;
using Xamarin.Essentials;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnowledgePage : ContentPage
    {
        private readonly KnowledgeDetail _Knowledge;
        knowledgePageViewModel vm;
        public KnowledgePage(KnowledgeDetail knowledge)
        {
            InitializeComponent();
            _Knowledge = knowledge;
            vm = new knowledgePageViewModel(knowledge);
            BindingContext = vm;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            vm.initialize();
            if (_Knowledge == null)
            {
                await Navigation.PopAsync();
            }
        }

        private async void OnNewFrameClicked(object sender, EventArgs e)
        {
            var popup = new KnowledgeCommentsPopup(vm.Item.id);
            popup.Disappearing += Popup_Disappearing;
            await PopupNavigation.Instance.PushAsync(popup);
        }

        private void Popup_Disappearing(object sender, EventArgs e)
        {
            vm.initialize();
        }

        private async void OnNotificationClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Notifications());
        }

        private void OnProfileClicked(object sender, EventArgs e)
        {

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

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            var url = (sender as Label).Text;
            try
            {
                await Browser.OpenAsync("https://www.google.com/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception errore)
            {

                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        private async void BackButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }

}