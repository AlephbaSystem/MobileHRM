using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewReference : PopupPage
    {
        public NewReference()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void Close_Imagebutton(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}