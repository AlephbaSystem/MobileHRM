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
        private readonly KnowledgePageViewModel vm;
        public KnowledgePage(KnowledgeDetail knowledge)
        {
            InitializeComponent();
            _Knowledge = knowledge;
            vm = new KnowledgePageViewModel(knowledge);
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
            await vm.RunIsBusyTaskAsync(async () =>
            {
                var popup = new KnowledgeCommentsPopup(vm.Item.id);
                popup.Disappearing += Popup_Disappearing;
                await PopupNavigation.Instance.PushAsync(popup);
            });
        }

        private async void Popup_Disappearing(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                vm.initialize();
            });
        }

        private async void OnNotificationClicked(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new Notifications());
            });
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

        string txt;
        private async void LinkTapped(object sender, EventArgs e)
        {
            NetworkAccess current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                await new ShowMsgPopup("cheak your internet connection", "Error").ShowAsync();
                return;
            }
            await vm.RunIsBusyTaskAsync(async () =>
            {
                Label obj = (Label)sender;
                txt = obj.Text;
                if (!txt.StartsWith("http://"))
                {
                    txt = "http://" + obj.Text;
                }
                try
                {
                    await Browser.OpenAsync(txt, BrowserLaunchMode.SystemPreferred);
                }
                catch (Exception e)
                {
                    throw;
                }
            });
        }

        private async void BackButtonClicked(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Shell.Current.Navigation.PopAsync();
            });
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            TapGestureRecognizer i = (TapGestureRecognizer)((Frame)sender).GestureRecognizers[0];
            var q = new KnowledgePage((KnowledgeDetail)i.CommandParameter);

        }
    }

}