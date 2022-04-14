using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;
namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IRPicker : PopupPage
    {
        private ViewModel.IRDatePickerViewModel vm;
        private bool ISave = true;
        public event EventHandler OnItemSelected;
        public string ManualDate { get; set; }

        public Command ManualDateCommand => new Command(() =>
        {
            if (DateTime.TryParse(ManualDate, out var date))
                vm.SelectedDate = date;
        });
        public async Task Show()
        {
            await PopupNavigation.Instance.PushAsync(this);
        }
        public IRPicker(DateTime Current)
        {
            InitializeComponent();
            vm = new ViewModel.IRDatePickerViewModel(Current);
            BindingContext = vm;
        }

        public IRPicker()
        {
            InitializeComponent();
            vm = new ViewModel.IRDatePickerViewModel(DateTime.Today);
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ISave = true;
        }
        protected override void OnDisappearing()
        {
            OnItemSelectedRaise();
            base.OnDisappearing();
        }
        private void OnItemSelectedRaise()
        {
            if (ISave) OnItemSelected(vm.SelectedDate, new EventArgs());
        }
        private async void SelectedDate_ItemSelected(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            await lbl.FadeTo(0.2, 400);
            await lbl.FadeTo(1, 400);
            OnItemSelectedRaise();
            await PopupNavigation.Instance.PopAllAsync();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            await lbl.FadeTo(0.2, 400);
            await lbl.FadeTo(1, 400);
            vm.SetSelectedDateExternal(DateTime.Now);
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            await lbl.FadeTo(0.2, 400);
            await lbl.FadeTo(1, 400);
            ISave = false;
            await PopupNavigation.Instance.PopAllAsync();
        }
    }
}