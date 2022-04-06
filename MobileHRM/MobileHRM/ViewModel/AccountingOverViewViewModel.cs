using MobileHRM.Api;
using MobileHRM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileHRM.ViewModel
{
    public class AccountingOverViewViewModel : Base
    {
        public AccountingOverViewViewModel()
        {
            request = new AccountingApi();
            Items = new List<AccountingOverView>();
            initializa();
        }
        List<AccountingOverView> _items;
        public List<AccountingOverView> Items
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
            var collection = await request.GetAllSubInvoice();
            for (int i = 0; i < collection.Count; i++)
            {
                if (i > 0 && collection[i].date != collection[i + 1].date)
                {
                    var itm = new AccountingOverView
                    {
                        Year = collection[i].date.Year.ToString()
                    };
                    decimal sum = 0;
                    itm.Months = new System.Collections.ObjectModel.ObservableCollection<Accounting>();
                    foreach (var col in collection)
                    {
                        if (col.date.Year == collection[i].date.Year)
                        {
                            sum += col.amount;
                            itm.Months.Add(new Accounting { Spent = col.amount, Month = col.date.Month.ToString() });
                            collection.Remove(col);
                        }
                    }
                    itm.Spent = sum;
                    Items.Add(itm);
                }
            }
        }
    }
}
