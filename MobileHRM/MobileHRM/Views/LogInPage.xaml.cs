using MobileHRM.Api;
using MobileHRM.Models.Request;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileHRM.Views
{
    [DesignTimeVisible(true)]
    public partial class LogInPage : ContentPage
    {
        AuthenticationApi authenticationApi = new AuthenticationApi();

        public LogInPage()
        {
            InitializeComponent();
        }


        private async void LogIn_Btn_Clk(object sender, EventArgs e)
        {
            NetworkAccess current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                await DisplayAlert("network", "cheak your internet connection", "ok");
                return;
            }

            if (!IsBusy)
            {
                IsBusy = true;

                if (string.IsNullOrEmpty(txtPhone.Text))
                {
                    await new Popup.ShowMsgPopup("Please enter your PhoneNumber", "Error").ShowAsync();
                    IsBusy = false;
                    return;
                }
                if (!IsValidPhone(txtPhone.Text))
                {
                    await new Popup.ShowMsgPopup("Please enter correct PhoneNumber", "Error").ShowAsync();
                    IsBusy = false;
                    return;
                }
                LoginRequest Lrequest = new LoginRequest()
                {
                    phoneNumber = txtPhone.Text,
                };
                if (await authenticationApi.Login(Lrequest))
                {
                    await Navigation.PushAsync(new VerifyPage(txtPhone.Text));
                }
                else await DisplayAlert("error", "check again", "ok");
                IsBusy = false;
            }
        }

        //private bool IsValidEmail(string emailaddress)
        //{
        //    return System.Text.RegularExpressions.Regex.IsMatch(emailaddress, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
        //}

        private bool IsValidPhone(string emailaddress)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(emailaddress, @"^(0|\+98)?([ ]|,|-|[()]){0,2}9[0|1|2|3|4]([ ]|,|-|[()]){0,3}(?:[0-9]([ ]|,|-|[()]){0,2}){8}$");
        }

        private async void OnImageButtonClicked(object sender, EventArgs e)
        {
            if (IsBusy == true)
            {
                IsBusy = true;
                ImageButton imageButton = (ImageButton)sender;
                Animation animation = new Animation(v => imageButton.Scale = v, 0.8, 1.3, Easing.SinInOut);
                animation.Commit(imageButton, "animate", 20, 200, Easing.SinIn);
                await imageButton.ScaleTo(1, 200, Easing.SinIn);
            }


            bool TC = await authenticationApi.TestConnection();
            await DisplayAlert("", TC.ToString(), "cancel");
            IsBusy = false;
        }
    }
}