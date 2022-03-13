using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.ViewModel;
using MobileHRM.Models.Api;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Knowledge : ContentView
    {
        KnowledgeViewModel vm;
        public Knowledge()
        {
            InitializeComponent();
            vm = new KnowledgeViewModel();
            BindingContext = vm;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var i=(TapGestureRecognizer)((Frame)sender).GestureRecognizers[0];
            await Navigation.PushAsync(new KnowledgePage((KnowledgeDetail)i.CommandParameter));
        }
    }
}

