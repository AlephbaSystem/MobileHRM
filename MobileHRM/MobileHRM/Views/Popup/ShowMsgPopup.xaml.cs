using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowMsgPopup : PopupPage
    {
        private int showMeliSec = 3000;


        public ShowMsgPopup(string msg, string type)
        {
            InitializeComponent();
            errText.Text = msg;
            switch (type)
            {
                case "Warning":
                    img.Source = "warnIcon.png";
                    prgresbar.ProgressColor = Color.FromHex("#EAC645");
                    break;
                case "Success":
                    img.Source = "succesIcon.png";
                    prgresbar.ProgressColor = Color.FromHex("#26AB5B");
                    break;
                case "Error":
                    img.Source = "errIcon.png";
                    prgresbar.ProgressColor = Color.FromHex("#D65745");
                    break;

                case "Information":
                default:
                    img.Source = "infoIcon.png";
                    prgresbar.ProgressColor = Color.FromHex("#5296D5");
                    break;
            }
        }

        public async Task ShowAsync()
        {
            prgresbar.ProgressTo(0, (uint)showMeliSec, Easing.Linear);
            await PopupNavigation.Instance.PushAsync(this);
        }

        private async void ExitButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void CloseClick(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}