
using MobileHRM.Models;
using MobileHRM.Views;
using Xamarin.Forms;


namespace MobileHRM
{
    public partial class App : Application
    {
        public App()
        {
            User.UserId = 2;
            User.UserName = "Test";
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
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
