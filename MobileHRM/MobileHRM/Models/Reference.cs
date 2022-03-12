using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileHRM.Models
{
    public class Reference
    {
        public string RefName { get; set; }
        public string RefLinkShow { get; set; }
        public Uri RefLink { get; set; }

        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    }
}
