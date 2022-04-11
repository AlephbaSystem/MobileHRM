using MobileHRM.Api;
using MobileHRM.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerifyPage : ContentPage
    {
        private AuthenticationApi authenticationApi = new AuthenticationApi();
        private string _loginPhone;
        private bool isTimerRun = false;
        private int seconds = 600; //timer

        //private Thread threadTime;

        public VerifyPage(string loginPhone)
        {
            InitializeComponent();
            _loginPhone = loginPhone;
        }

        private async void Verify_Btn_Clk(object sender, EventArgs e)
        {
            VerifyRequest Vrequest = new VerifyRequest()
            {
                phoneNumber = _loginPhone,
                verifyCode = txtCode.Text
            };
            if (await authenticationApi.Validate(Vrequest))
            {
                await Navigation.PushAsync(new NavigationPage());
            }
            else await DisplayAlert("error", "check again", "ok");
            IsBusy = false;
        }

        private async void ResendSmsTapped(object sender, EventArgs e)
        {
            if (!IsBusy == true)
            {
                if (!isTimerRun)
                {
                    isTimerRun = true;
                    await Task.Run(async () =>
                    {
                        seconds = 600;
                        await TimerSendSms();
                    });
                }

                IsBusy = true;
                Label label = (Label)sender;
                Animation animation = new Animation(v => label.Scale = v, 0.8, 1.3, Easing.SinInOut);
                animation.Commit(label, "animate", 20, 200, Easing.SinIn);
                await label.ScaleTo(1, 200, Easing.SinIn);
            }
            IsBusy = false;
        }



        //DateTime seconds = new DateTime(0,0,0,0,0,600);
        private async Task TimerSendSms()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                seconds--;
                lblTime.Text = seconds.ToString();
                if (seconds == 0)
                {
                    isTimerRun = false;
                    return false;
                }
                return true;
            });
        }

        private void OnImageButtonClicked(object sender, EventArgs e)
        {

        }
    }
}