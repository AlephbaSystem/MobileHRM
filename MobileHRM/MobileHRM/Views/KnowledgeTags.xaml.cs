using MobileHRM.ViewModel;
using MobileHRM.Views.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnowledgeTags : ContentPage
    {
        private readonly KnowledgeNewViewModel vm = new KnowledgeNewViewModel();
        public KnowledgeTags(KnowledgeNewViewModel _vm)
        {
            InitializeComponent();
            vm = _vm;
            BindingContext = vm;
            MakeColor();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void New_Clicked(object sender, EventArgs e)
        {
            //await PopupNavigation.Instance.PushAsync(new NewTag(vm));
            vm.KnowledgeDetail.tags.Add(new Models.Entities.Request.tag()
            {
                color = ColorEntry.Text ?? "#fff",
                tagName = TagEntry.Text
            });
            vm.KnowledgeDetail = vm.KnowledgeDetail;
            TagEntry.Text = "";
            MakeColor();
        }

        private async void OnClear_Tapped(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Warning!", "Data Will be Lost \nAre You Sure? ", "Accept", "Cancel");
            if (res)
            {
                vm.KnowledgeDetail.tags.Clear();
                vm.KnowledgeDetail.tags = vm.KnowledgeDetail.tags;
            }
        }

        private void MakeColorClicked(object sender, EventArgs e)
        {
            MakeColor();
        }

        private void MakeColor()
        {
            int code = new Random().Next(100000, 999999);
            string ColorCode = "#" + code;
            Color color = Color.FromHex(ColorCode);
            ColorButton.BackgroundColor = color;
            ColorEntry.Text = ColorCode;
        }

        private void ColorEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ColorEntry.Text) && ColorEntry.Text.StartsWith("#"))
            {
                Color color = Color.FromHex(ColorEntry.Text);
                ColorButton.BackgroundColor = color;
            }
        }
    }
}