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
            save = new Command(ClearBusiness);
            clear = new Command(SaveBusiness);
        }
        private Models.Api.Business _business;
        public Models.Api.Business business
        {
            get => _business;
            set
            {
                _business = value;
                OnPropertyChanged(nameof(business));
            }
        }
        AccountingApi Api;
        private async void SaveBusiness()
        {
            business.employeeId = User.UserId;
            await Api.PostBusiness(business);
        }
        private void ClearBusiness()
        {
            business = new Models.Api.Business();

        }
        public ICommand save { get; protected set; }
        public ICommand clear { get; protected set; }
    }
}
