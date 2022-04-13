using MobileHRM.Api;
using MobileHRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHRM.ViewModel
{
    public class AddBusinessViewModel : Base
    {
        public AddBusinessViewModel()
        {
            Api = new AccountingApi();
            business = new Models.Api.Business();
            save = new Command(SaveBusiness);
            clear = new Command(ClearBusiness);
        }
        private Models.Api.Business _business;
        public Models.Api.Business business
        {
            get
            {

                return _business ?? new Models.Api.Business();
            }
            set
            {
                _business = value;
                OnPropertyChanged(nameof(business));                
            }
        }
        AccountingApi Api;
        private async void SaveBusiness()
        {
            IsEnabled = !string.IsNullOrEmpty(business.name);
            if (!IsEnabled)
            {
                return;
            }
            business.employeeId = User.UserId;
            await Api.PostBusiness(business);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private void ClearBusiness()
        {
            business = new Models.Api.Business();
        }
        public ICommand save { get; protected set; }
        public ICommand clear { get; protected set; }
        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }
    }
}