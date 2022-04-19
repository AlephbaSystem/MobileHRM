using MobileHRM.Models.Entities;
using MobileHRM.Models.Entities.Request;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Messages_Edit : PopupPage
    {
        ViewModel.MessageEditViewModel Vm;
        public Messages_Edit(Group group)
        {
            InitializeComponent();
            Vm= new ViewModel.MessageEditViewModel(group);
            BindingContext = Vm;
        }
        protected override bool OnBackButtonPressed()
        {
            pop();
            return base.OnBackButtonPressed();            
        }
        private async void pop()
        {
            await PopupNavigation.Instance.PopAsync();
        }
        private async void Close_Imagebutton(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
        private void UserTapGestureRecognizer(object sender, EventArgs e)
        {

        }

        private void Add_Clicked(object sender, EventArgs e)
        {

        }
    }
}