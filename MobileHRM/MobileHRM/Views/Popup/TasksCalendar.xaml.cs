using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksCalendar : PopupPage
    {
        public TasksCalendar()
        {
            InitializeComponent();
        }

        private async void OnExitImageButtonClicked(object sender, EventArgs e)
        {
            Animation animation = new Animation(v => ImageExitPunchIn.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(ImageExitPunchIn, "animate", 20, 200, Easing.SinIn);
            await ImageExitPunchIn.ScaleTo(1, 200, Easing.SinIn);
            await PopupNavigation.Instance.PopAsync();
        }
    }
}