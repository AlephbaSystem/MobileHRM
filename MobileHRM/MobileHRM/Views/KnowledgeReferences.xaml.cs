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
    public partial class KnowledgeReferences : ContentPage
    {
        private readonly ViewModel.KnowledgeNewViewModel _vm;
        public KnowledgeReferences(ViewModel.KnowledgeNewViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ReferenceEntry.Text) && !string.IsNullOrEmpty(LinkEntry.Text))
            {
                _vm.KnowledgeDetail.references.Add(new Models.Entities.Request.reference()
                {
                    referencesName = ReferenceEntry.Text,
                    link = LinkEntry.Text,
                    adress = ""
                });
                _vm.KnowledgeDetail = _vm.KnowledgeDetail;
                LinkEntry.Text = ReferenceEntry.Text = "";
            }
            //await PopupNavigation.Instance.PushAsync(new NewReference(_vm));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Warning!", "Data Will be Lost \nAre You Sure? ", "Accept", "Cancel");
            if (res)
            {
                _vm.KnowledgeDetail.references.Clear();
                _vm.KnowledgeDetail.references = _vm.KnowledgeDetail.references;
            }
        }
    }
}