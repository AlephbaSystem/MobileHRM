using MobileHRM.Api;
using MobileHRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHRM.ViewModel
{
    public class AccountingOverViewViewModel : Base
    {
        public AccountingOverViewViewModel()
        {
            request = new AccountingApi();
            Items = new ObservableCollection<AccountingOverView>();
            initializa();
        }
        ObservableCollection<AccountingOverView> _items;
        public ObservableCollection<AccountingOverView> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        AccountingApi request;
        public async void initializa()
        {
            Items = new ObservableCollection<AccountingOverView>();
            var collection = await request.GetAllSubInvoice();
            Items = new ObservableCollection<AccountingOverView>(from p in collection
                                                                 group p by p.date.Year into g
                                                                 select new
                                                                 AccountingOverView
                                                                 { Year = g.Key.ToString(), Months = new ObservableCollection<Accounting>((from i in g select new Accounting { Month = i.date.ToString("MMMM"), Spent = i.amount }).ToList()), Spent = g.Sum(j => j.amount) });
        }
    }
}