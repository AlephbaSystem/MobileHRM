using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
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
    public partial class ShowMsgPopup : PopupPage
    {
        private bool isShow { get; set; }
        private int showMeliSec { get; set; }
       

        public ShowMsgPopup(string msg, string type, int showForSec)
        {
            InitializeComponent();
            errText.Text = msg;
            showMeliSec = showForSec * 1000;
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
            isShow = true;
            await PopupNavigation.Instance.PushAsync(this);
            await prgresbar.ProgressTo(0, (uint)showMeliSec, Easing.Linear);
            if (isShow)
                await PopupNavigation.Instance.PopAsync();
           
        }

        private async void ExitButton_Clicked(object sender, EventArgs e)
        {
            isShow = false;

            await PopupNavigation.Instance.PopAsync();
        }
        

        protected override bool OnBackgroundClicked()
        {
            isShow = false;
            return base.OnBackgroundClicked();
        }

        protected override bool OnBackButtonPressed()
        {
            isShow = false;
            return base.OnBackButtonPressed();
        }



    }
}