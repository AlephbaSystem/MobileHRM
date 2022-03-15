using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.Models.Api;
using MobileHRM.ViewModel;
using MobileHRM.Models.Entities;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnowledgePage : ContentPage
    {
        private readonly KnowledgeDetail _Knowledge;
        knowledgePageViewModel vm;
        public KnowledgePage(KnowledgeDetail knowledge)
        {
            InitializeComponent();
            _Knowledge = knowledge;
            vm = new knowledgePageViewModel(knowledge);
            BindingContext = vm;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (_Knowledge == null)
            {
                await Task.Delay(1000);
                await Navigation.PopAsync();
            }
        }
    }
}