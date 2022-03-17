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
                await Task.Delay(1000);
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
    }
}