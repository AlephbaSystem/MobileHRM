using MobileHRM.Database;
using MobileHRM.Models;
using MobileHRM.Views;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MobileHRM
{
    public partial class App : Application
    {
        UserDatabase userDb;
        public App()
        {
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            check();
        }
        private async void check()
        {
                userDb= UserDatabase.Instance.GetAwaiter().GetResult();
                var q=await userDb.GetUserAsync();
                if (string.IsNullOrEmpty(q.token))
                {
                    MainPage = new NavigationPage(new LogInPage());
                }
                else
                {
                    User.UserId = q.UserId;
                    User.UserName = "alephba";
                    MainPage = new MainPage();
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
