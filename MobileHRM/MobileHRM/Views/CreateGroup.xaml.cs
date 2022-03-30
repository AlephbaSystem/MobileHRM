using MobileHRM.Api;
using MobileHRM.Models;
using MobileHRM.Models.Api;
using MobileHRM.Models.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateGroup : ContentPage
    {

        public CreateGroup(List<Models.Entities.Request.Contact> items)
        {
            InitializeComponent();
            UsersList.ItemsSource = items;
            group.users = (from p in items select p.userId).ToList();
            group.users.Add(User.UserId);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }

        private async void Browse_Group_Image(object sender, EventArgs e)
        {
            var photo = await MediaPicker.PickPhotoAsync();
            if (photo != null)
            {
                GroupPicture.HorizontalOptions = LayoutOptions.FillAndExpand;
                GroupPicture.VerticalOptions = LayoutOptions.FillAndExpand;
                GroupPicture.Source = ImageSource.FromFile(photo.FullPath);
                using (var stream = await photo.OpenReadAsync())
                {
                    group.image = new byte[(int)stream.Length];
                    await stream.ReadAsync(group.image, 0, (int)stream.Length);
                }
            }
        }
        ChatApi request = new ChatApi();
        createGroup group = new createGroup();
        private async void Save_Clicked(object sender, EventArgs e)
        {
            IsBusy = true;
            if (!IsBusy)
            {
                group.name = GroupName.Text ?? "";
                group.ownerId = User.UserId;
                bool res = await request.CreateGroup(group);
                IsBusy = false;
                if (res)
                {
                    await Navigation.PopToRootAsync();
                }
            }                                                
        }
    }
}