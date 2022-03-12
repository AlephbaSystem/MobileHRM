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
        private bool isRecording{ set; get; }
        public CameraViews()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            isRecording = false;
            
        }

        private void CaptureImage(object sender, EventArgs e)
        {
            if (isRecording)
            {
                isRecording = false;
                xctCameraView.Shutter();
                xctCameraView.CaptureMode = CameraCaptureMode.Photo;
                RecImgBtn.Source = "cam.png";
            }
            else
            {
                xctCameraView.CaptureMode = CameraCaptureMode.Photo;
                xctCameraView.Shutter();
            }
        }
        private void RecordVideo(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                xctCameraView.CaptureMode = CameraCaptureMode.Video;
                isRecording = true;
                RecImgBtn.Source = "stopRec.png";
            }
            else
            {
                isRecording = false;
                RecImgBtn.Source = "rec.png";


            }
            xctCameraView.Shutter();
        }
        

        

        private async void MediaCaptured(object sender, MediaCapturedEventArgs e)
        {

            if (xctCameraView.CaptureMode == CameraCaptureMode.Photo)
            {
                ImageEdit imgEdit = new ImageEdit(e.Image);
                Navigation.PushAsync(imgEdit);
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

     

        private void switchCam(object sender, EventArgs e)
        {
            if (xctCameraView.CameraOptions == CameraOptions.Back)
                xctCameraView.CameraOptions = CameraOptions.Front;
            else
                xctCameraView.CameraOptions = CameraOptions.Back;

            zoomslider.Maximum = xctCameraView.MaxZoom;
        }
    }
}