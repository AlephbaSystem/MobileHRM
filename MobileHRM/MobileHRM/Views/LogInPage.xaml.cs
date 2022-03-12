using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Security.Cryptography;
using System.Net.Mail;

namespace MobileHRM.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void LogIn_Btn_Clk(object sender, EventArgs e)
        {
            if (pass.Text == "" || email.Text == "" || pass.Text ==null || email.Text == null)
                   await new Popup.ShowMsgPopup("Please enter your username and password" , "Error" , 3).ShowAsync();
            else if (!IsValidMail(email.Text))
                   await new Popup.ShowMsgPopup("Please enter correct Email" , "Error" , 3).ShowAsync();

            else
            {
                string hashPass = BCrypt.Net.BCrypt.HashPassword(pass.Text);
                await new Popup.ShowMsgPopup(hashPass, "Information", 2).ShowAsync();
                await Navigation.PushAsync(new CameraViews());
            
            

            }
        }

        private static bool IsValidMail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}