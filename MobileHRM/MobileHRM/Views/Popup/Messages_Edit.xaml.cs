using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Messages_Edit : PopupPage
    {
        readonly ViewModel.MessageEditViewModel Vm = new ViewModel.MessageEditViewModel();
        public Messages_Edit(ViewModel.MessageEditViewModel vm)
        {
            InitializeComponent();
           Vm = vm;
            BindingContext = Vm;
        }

        private async void Close_Imagebutton(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
        private void UserTapGestureRecognizer(object sender, EventArgs e)
        {

        }

        private void Add_Clicked(object sender, EventArgs e)
        {

        }
    }
}