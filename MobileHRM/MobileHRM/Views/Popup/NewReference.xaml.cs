using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewReference : PopupPage
    {
        private readonly ViewModel.KnowledgeNewViewModel _vm = new ViewModel.KnowledgeNewViewModel();
        public NewReference(ViewModel.KnowledgeNewViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            _vm.KnowledgeDetail.references.Add(new Models.Entities.Request.reference() { link = Link.Text, referencesName = Reference.Text, adress = "" });
            _vm.KnowledgeDetail = _vm.KnowledgeDetail;
            await Task.Delay(500);
            await PopupNavigation.Instance.PopAsync();
        }

        private async void Close_Imagebutton(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}