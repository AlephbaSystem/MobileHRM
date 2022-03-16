using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewReference : PopupPage
    {
        MobileHRM.ViewModel.KnowledgeNew _vm = new ViewModel.KnowledgeNew();
        public NewReference(ViewModel.KnowledgeNew vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _vm.KnowledgeDetail.references.Add(new Models.Entities.Request.reference { link = Link.Text, referencesName = Reference.Text });
        }

        private async void Close_Imagebutton(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}