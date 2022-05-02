using MobileHRM.Api;
using MobileHRM.Models;
using MobileHRM.ViewModel;
using MobileHRM.Models.Api;
using MobileHRM.Models.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateGroup : ContentPage
    {
        ViewModel.Base vm;

       

        public CreateGroup(List<Models.Entities.Request.Contact> items)
        {
            InitializeComponent();
            vm =new ViewModel.Base();
            UsersList.ItemsSource = items;
            group.users = (from p in items select p.userId).ToList();
            group.users.Add(User.UserId);
            group.image = new byte[0];
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private async void Notification(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new Popup.Notifications());
            });

        }

        private async void Browse_Group_Image(object sender, EventArgs e)
        {

            FileResult photo = await MediaPicker.PickPhotoAsync();
            await vm.RunIsBusyTaskAsync(async () =>
            {

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
            });
        }
        ChatApi request = new ChatApi();
        createGroup group = new createGroup();
        private async void Save_Clicked(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                if (!IsBusy)
                {
                    IsBusy = true;
                    group.name = GroupName.Text ?? "";
                    group.ownerId = User.UserId;
                    bool res = await request.CreateGroup(group);
                    IsBusy = false;
                    if (res)
                    {
                        await Navigation.PopToRootAsync();
                    }
                }
            });
        }

        private async void ArrowBack(object sender, EventArgs e)
        {
            await vm.RunIsBusyTaskAsync(async () =>
            {
                await Navigation.PopAsync();
            });
        }
    }
}