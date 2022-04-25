using Lottie.Forms;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loading : PopupPage
    {
        public Loading()
        {
            InitializeComponent();
        }

        public async Task Show()
        {
            
            await PopupNavigation.Instance.PushAsync(this);
           
        }
        public async Task Hide()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
        public async Task Hideall()
        {
            await Task.Delay(100);
            for (int i = 0; i < PopupNavigation.Instance.PopupStack.Count; i++)
            {
                var item = PopupNavigation.Instance.PopupStack[i];
                if (item.GetType() == typeof(Loading))
                    await PopupNavigation.Instance.RemovePageAsync(PopupNavigation.Instance.PopupStack[i]);
            }

        }
    }
}