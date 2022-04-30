using MobileHRM.Database;
using MobileHRM.Models;
using MobileHRM.Views;
using Xamarin.Forms;
using System;


namespace MobileHRM
{
    public partial class App : Application
    {        
        public App()
        {
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            //MainPage = new VerifyPage();
            OnCheck();
        }

        private UserAuthDatabase userDb;

        private async void OnCheck()
        {
            userDb = UserAuthDatabase.Instance.GetAwaiter().GetResult();
            Models.Entities.UserAutentication q = await userDb.GetUserAsync();
            if (q != null)
            {
                TimeSpan time = DateTime.Now - q.tokenExpire;
                if (time.Days <= 30)
                {
                    User.UserId = q.userId;
                    User.UserName = string.IsNullOrEmpty(q.userName) ? "alephba" : q.userName;
                    MainPage = new MainPage();
                }
                else
                    MainPage = new NavigationPage(new LogInPage());
            }
            else
                MainPage = new NavigationPage(new LogInPage());
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
