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
        }

        private void LogIn_Btn_Clk(object sender, EventArgs e)
        {
            if (pass.Text == "" || email.Text == "" || pass.Text == null || email.Text == null)
                   new Popup.ShowMsgPopup("Please enter your username and password" , "Error" , 3);
            else if (!IsValidMail(email.Text))
                   new Popup.ShowMsgPopup("Please enter correct Email" , "Error" , 3);

            else
            {
                string hashPass = BCrypt.Net.BCrypt.HashPassword(pass.Text);
                new Popup.ShowMsgPopup(hashPass, "Information", 10);
            
            

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