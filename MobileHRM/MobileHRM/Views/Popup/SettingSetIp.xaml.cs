using MobileHRM.Database;
using MobileHRM.Interfaces;
using MobileHRM.Models.Request;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingSetIp : PopupPage
    {
        IpAddressDataBase db;
        IMEIInterface mEI;
        static string ip;
        public SettingSetIp()
        {
            InitializeComponent();
            IpAddresstxt.Text = ip;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            db = await IpAddressDataBase.Instance;
        }

        private async void Back_Click(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }

        private async void btn_Save(object sender, EventArgs e)
        {
            ip = IpAddresstxt.Text;
            bool valid = await db.SaveUserAsync(new Models.IpAddress { ipAddress = IpAddresstxt.Text });
            if (valid)
                await new Popup.ShowMsgPopup("IpAddress saved !!!", "Success").ShowAsync();
            else
                await new Popup.ShowMsgPopup("IpAddress is not Valid !!!", "Error").ShowAsync();
            MobileHRM.Helper.Statics.IP = IpAddresstxt.Text;



        }
    }
}