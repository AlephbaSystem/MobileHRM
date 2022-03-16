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
        MobileHRM.ViewModel.KnowledgeNew vm = new ViewModel.KnowledgeNew();
        public KnowledgeNew()
        {
            InitializeComponent();
            BindingContext = vm;
            //BindableLayout.SetItemsSource(cView, tempDate());
        }

        private async void OnReferenceClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KnowledgeReferences(vm));
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Warning!", "The Data Will Be Lose \n Are you Continue?", "Accept", "Cancel");
            if (res)
            {
                await Navigation.PopAsync();
            }
        }
    }

}