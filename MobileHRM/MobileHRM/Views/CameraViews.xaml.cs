using MobileHRM.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraViews : ContentPage
    {
        public CameraViews()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private void CaptureImage(object sender, EventArgs e)
        {
            xctCameraView.Shutter();
        }
        private void RecordVideo(object sender, EventArgs e)
        {
            xctCameraView.Shutter();
            btnrecordVideo.IsEnabled = false;
            btnstopVideo.IsEnabled = true;
        }
        private void StopVideo(object sender, EventArgs e)
        {
            xctCameraView.Shutter();
            btnrecordVideo.IsEnabled = true;
            btnstopVideo.IsEnabled = false;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (xctCameraView.CaptureMode == CameraCaptureMode.Photo)
            {
                xctCameraView.CaptureMode = CameraCaptureMode.Video;

                captureBtn.IsEnabled = false;
                btnrecordVideo.IsEnabled = true;
                btnstopVideo.IsEnabled = false;
            }
            else
            {
                xctCameraView.CaptureMode = CameraCaptureMode.Photo;

                captureBtn.IsEnabled = true;
                btnrecordVideo.IsEnabled = false;
                btnstopVideo.IsEnabled = false;
            }
        }

        private async void MediaCaptured(object sender, MediaCapturedEventArgs e)
        {
            if (xctCameraView.CaptureMode == CameraCaptureMode.Photo)
            {
                var bytes = e.ImageData;
                var request = new KnowledgeApi();
                var res = await request.PostUserProfile(new Models.Api.UserProfile { image = bytes, userId = 2, userName = "Stone" });
                _ = 5;
            }
            //else
            //{
            //    imgView.Source = e.Video.File;
            //    imgView.IsAnimationPlaying = true;
            //    imgViewPanel.IsVisible = true;
            //}

            //string str;
            //if (xctCameraView.CaptureMode == CameraCaptureMode.Photo)
            //    str = e.Image.ToString();
            //else
            //    str = e.Video.File;

        }

        private void CloseImageView(object sender, EventArgs e)
        {
            //imgViewPanel.IsVisible = false;
        }

        private void switchCam_Toggled(object sender, ToggledEventArgs e)
        {
            if (xctCameraView.CameraOptions == CameraOptions.Back)
                xctCameraView.CameraOptions = CameraOptions.Front;
            else
                xctCameraView.CameraOptions = CameraOptions.Back;

            zoomslider.Maximum = xctCameraView.MaxZoom;
        }

    }
}