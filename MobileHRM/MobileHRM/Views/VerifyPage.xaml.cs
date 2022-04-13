using MobileHRM.Api;
using MobileHRM.Database;
using MobileHRM.Models;
using MobileHRM.Models.Entities;
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
        private bool isTimerRun = true;
        private int seconds = 600; //timer



        public VerifyPage(string loginPhone)
        {
            InitializeComponent();
            _loginPhone = loginPhone;
            TimerSendSms();
        }

        private async void Verify_Btn_Clk(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                VerifyRequest Vrequest = new VerifyRequest()
                {
                    phoneNumber = _loginPhone,
                    verifyCode = txtCode.Text
                };
                var q = await authenticationApi.Validate(Vrequest);
                if (q != null)
                {
                    var user = new UserEntitieModel()
                    {
                        phone = _loginPhone,
                        token = q.token,
                        createdAt = DateTime.Now,
                        Id = q.userId,
                    };
                    User.UserId = user.Id;
                    var userDatabase = UserDatabase.Instance.GetAwaiter().GetResult();
                    await userDatabase.SaveUserAsync(user);
                    Application.Current.MainPage = new MainPage();
                }

                else await DisplayAlert("error", "check again", "ok");
                IsBusy = false;
            }

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
                        LoginRequest Lrequest = new LoginRequest()
                        {
                            phoneNumber = _loginPhone,
                        };
                        if (await authenticationApi.Login(Lrequest))
                        {
                            seconds = 600;
                            await TimerSendSms();
                        }
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