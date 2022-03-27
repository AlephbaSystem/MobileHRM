using MobileHRM.ViewModel;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTag : PopupPage
    {
        KnowledgeNewViewModel vm = new KnowledgeNewViewModel();
        public NewTag(KnowledgeNewViewModel _vm)
        {
            InitializeComponent();
            vm = _vm;
        }

        private async void On_AddClicked(object sender, EventArgs e)
        {
            vm.KnowledgeDetail.tags.Add(new Models.Entities.Request.tag() { color = TagColor.Text ?? "#fff", tagName = TagName.Text });
            vm.KnowledgeDetail = vm.KnowledgeDetail;
            await Task.Delay(500);
            await PopupNavigation.Instance.PopAsync();
        }

        private async void Close_Imagebutton(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}