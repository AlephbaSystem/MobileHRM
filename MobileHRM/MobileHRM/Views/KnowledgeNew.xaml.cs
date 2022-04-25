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
    public partial class KnowledgeNew : ContentPage
    {
        MobileHRM.ViewModel.KnowledgeNewViewModel vm;
        public KnowledgeNew()
        {
            InitializeComponent();
            vm = new ViewModel.KnowledgeNewViewModel();
            BindingContext = vm;
            //BindableLayout.SetItemsSource(cView, tempDate());
        }
        protected override void OnAppearing()
        {            
            base.OnAppearing();
            vm.KnowledgeDetail = vm.KnowledgeDetail;
        }
        private async void OnReferenceClicked(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Navigation.PushAsync(new KnowledgeReferences(vm));
            });
        }

        private async void OnClearClicked(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            { 
            bool res = await DisplayAlert("Warning!", "The Data Will Be Lose \n Are you Continue?", "Accept", "Cancel");
            if (res)
            {
                vm.KnowledgeDetail = new Models.Api.PostKnoweldgeDetail();
            }
        });
        }

        private async void On_TagsTapped(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Navigation.PushAsync(new KnowledgeTags(vm));
            });
        }
    }

}