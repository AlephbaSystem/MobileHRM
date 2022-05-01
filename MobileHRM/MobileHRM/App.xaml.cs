using MobileHRM.Database;
using MobileHRM.Models;
using MobileHRM.Views;
using Xamarin.Forms;
using System;


namespace MobileHRM
{
    public partial class App : Application
    {
        private UserAuthDatabase userDb;
        public App()
        {
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            //MainPage = new MainPage();
            check();
        }
        private async void check()
        {
            userDb = UserAuthDatabase.Instance.GetAwaiter().GetResult();
            Models.Entities.UserAutentication q = await userDb.GetUserAsync();
            if (q != null)
            {
                TimeSpan time = DateTime.Now - q.tokenExpire;
                if (time.Days <= 30)
                {
                    User.UserId = q.userId;
                    if (string.IsNullOrEmpty(q.userName))
                    {
                        User.UserName = "alephba";
                    }
                    else
                    {
                        User.UserName = q.userName;
                    }
                    MainPage = new MainPage();
                }
                else
                {
                    MainPage = new NavigationPage(new LogInPage());
                }
            }
            else
            {
                MainPage = new NavigationPage(new LogInPage());
            }
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
