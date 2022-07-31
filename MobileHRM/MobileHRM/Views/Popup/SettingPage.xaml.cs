using MobileHRM.Api;
using MobileHRM.Models.Entities.Request;
using MobileHRM.Models.Request;
using MobileHRM.ViewModel;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatUser : PopupPage
    {
        private readonly UserRegisterApi api;
        string city;
      
     

        public CreatUser()
        {
            InitializeComponent();
            api = new UserRegisterApi();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            UserRegisterRequest model = new UserRegisterRequest
            {
                Name = Nametxt.Text,
                Email = Emailtxt.Text,
                Address = Addresstxt.Text,
                Phone = Phonetxt.Text
            };
            model.City = city;
            await api.UserRegister(model);

        }


        private async void Browse_Group_Image(object sender, EventArgs e)
        {

            FileResult photo = await MediaPicker.PickPhotoAsync();

            if (photo != null)
            {
                GroupPicture.HorizontalOptions = LayoutOptions.FillAndExpand;
                GroupPicture.VerticalOptions = LayoutOptions.FillAndExpand;
                GroupPicture.Source = ImageSource.FromFile(photo.FullPath);
                //using (var stream = await photo.openreadasync())
                //{
                //    group.image = new byte[(int)stream.length];
                //    await stream.readasync(group.image, 0, (int)stream.length);
                //}
            }
        }

       
        private async void City_Tapped(object sender, EventArgs e)
        {
            string result = await DisplayActionSheet("Choose City: ", "Back", null, new string[] { "Mashhad", "Tehran", "Neishabor", "Esfahan", "Yazd" });
            if (result != "back")
            {
                city = result;
               //vm.UserRegister.city = result;
               // vm.UserRegister = vm.UserRegister;
            }
        }

        private async void Back(object sender, EventArgs e)
        {

           await PopupNavigation.Instance.PopAllAsync();

        }

        private bool DashBoard()
        {
            throw new NotImplementedException();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}