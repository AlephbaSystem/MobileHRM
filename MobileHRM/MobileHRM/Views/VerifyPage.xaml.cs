using MobileHRM.Api;
using MobileHRM.Database;
using MobileHRM.Models.Entities;
using MobileHRM.Models.Request;
using MobileHRM.Models.Response;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerifyPage : ContentPage
    {
        private readonly AuthenticationApi authenticationApi = new AuthenticationApi();
        private readonly string _loginPhone;
        private bool isTimerRun = true;
        private int seconds = 181; //timer       

        public VerifyPage(string loginPhone)
        {
            InitializeComponent();
            TimerSendSms();
            _loginPhone = loginPhone;
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
                VerifyResponse Vresponse = await authenticationApi.Validate(Vrequest);
                if (Vresponse.token != null)
                {
                    await SaveToDatabase(Vresponse);
                    Application.Current.MainPage = new MainPage();
                }
                else
                    await new Popup.ShowMsgPopup(Vresponse.Content, "").ShowAsync();
                IsBusy = false;
            }
        }

        private async Task SaveToDatabase(VerifyResponse Vresponse)
        {
            UserEntitieModel user = new UserEntitieModel()
            {
                phone = _loginPhone,
                createdAt = DateTime.Now,
            };
            UserAutentication userAuth = new UserAutentication()
            {
                token = Vresponse.token,
                tokenExpire = DateTime.Now,
                userId = Vresponse.userId,
                userName = Vresponse.UserName
            };
            UserDatabase userDatabase = UserDatabase.Instance.GetAwaiter().GetResult();
            await userDatabase.SaveUserAsync(user);
            UserAuthDatabase userAuthDatabase = UserAuthDatabase.Instance.GetAwaiter().GetResult();
            await userAuthDatabase.SaveUserAutAsync(userAuth);
        }

        private async void ResendSmsTapped(object sender, EventArgs e)
        {
            if (!IsBusy)
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
                        RMessage q = await authenticationApi.Login(Lrequest);
                        if (q.IsSuccess)
                        {
                            seconds = 181;
                            await TimerSendSms();
                        }
                        else
                        {
                            await new Popup.ShowMsgPopup(q.Content, "Warning").ShowAsync();
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
                lblTime.Text = $"{seconds / 60}:{seconds % 60}";
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