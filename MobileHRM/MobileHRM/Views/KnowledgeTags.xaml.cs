using MobileHRM.ViewModel;
using MobileHRM.Views.Popup;
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
    public partial class KnowledgeTags : ContentPage
    {
        KnowledgeNewViewModel vm = new KnowledgeNewViewModel();
        public KnowledgeTags(KnowledgeNewViewModel _vm)
        {
            InitializeComponent();
            vm = _vm;
            BindingContext = vm;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new NewTag(vm));
        }

        private async void OnClear_Tapped(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Warning!", "Data Will be Lost \nAre You Sure? ", "Accept", "Cancel");
            if (res)
            {
                vm.KnowledgeDetail.tags.Clear();
                vm.KnowledgeDetail.tags = vm.KnowledgeDetail.tags;
            }
        }
    }
}