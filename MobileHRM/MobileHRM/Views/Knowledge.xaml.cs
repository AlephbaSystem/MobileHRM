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
    public partial class Knowledge : ContentPage
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

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {

        }
    }
}

