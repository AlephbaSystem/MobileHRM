using System;
using System.ComponentModel;
using Xamarin.Forms;

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
        }

        private async void LogIn_Btn_Clk(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pass.Text) || string.IsNullOrEmpty(email.Text))
            {
                await new Popup.ShowMsgPopup("Please enter your username and password", "Error", 3).ShowAsync();
                return;
            }
            if (!IsValidEmail(email.Text))
            {
                await new Popup.ShowMsgPopup("Please enter correct Email", "Error", 3).ShowAsync();
                return;
            }

            string hashPass = BCrypt.Net.BCrypt.HashPassword(pass.Text);
            await new Popup.ShowMsgPopup(hashPass, "Information", 2).ShowAsync();
            await Navigation.PushAsync(new CameraViews());
        }

        private bool IsValidEmail(string emailaddress)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(emailaddress, @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
        }
    }
}