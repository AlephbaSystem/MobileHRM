using Rg.Plugins.Popup.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;
using MobileHRM.Views;
using Xamarin.CommunityToolkit.UI.Views;
using System.Threading.Tasks;
using MobileHRM.ViewModel;
using MobileHRM.Models;
using MobileHRM.Views.Popup;
using MobileHRM.Database;

namespace MobileHRM
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
        }

    }
}