using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTag : PopupPage
    {
        public NewTag()
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