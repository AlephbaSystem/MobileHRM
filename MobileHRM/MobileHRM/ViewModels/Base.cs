using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MobileHRM.ViewModels
{
    public class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void unPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

        private bool IsBusy { get; set; }
        public async void Run(Func<Task> func)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                try { await func(); }
                finally
                {
                    IsBusy = false;
                }

            }

        }
    }

}