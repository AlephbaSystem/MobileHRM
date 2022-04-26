using MobileHRM.Views.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MobileHRM.ViewModel
{
    public class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public bool IsBusy { get; set; }

        public async Task RunIsBusyTaskAsync(Func<Task> awaitableTask, bool IsLoading = true)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Loading lod = new Loading();
            try
            {
                await lod.Show();
                await awaitableTask();
            }
            catch (Exception ex)
            {
                _ = ex.Message.ToString();
            }
            finally
            {
                IsBusy = false;
                await lod.Hideall();
            }
        }

    }
}
