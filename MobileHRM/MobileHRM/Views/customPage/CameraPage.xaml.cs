using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.customPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage
    {
        bool isImage = true;
        public CameraPage()
        {
            InitializeComponent();
        }

        private void MediaCaptured(object sender, MediaCapturedEventArgs e)
        {
            if (!isImage)
            {
                imgView.Source = e.Image;                
                imgViewPanel.IsVisible = true;
            }
            else
            {
                imgView.Source = e.Video.File;
                imgViewPanel.IsVisible = true;
            }
            
        }

        private void CloseImageView(object sender, EventArgs e)
        {
            imgViewPanel.IsVisible = false;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (cameraView.CaptureMode == CameraCaptureMode.Photo)
            {
                captureMode.Text = "Video";
                cameraView.CaptureMode = CameraCaptureMode.Video;
                isImage = false;
                captureBtn.IsEnabled = false;
                btnrecordVideo.IsEnabled = true;
                btnstopVideo.IsEnabled = false;
            }
            else
            {
                captureMode.Text = "Photo";
                cameraView.CaptureMode = CameraCaptureMode.Photo;
                isImage = true;
                captureBtn.IsEnabled = true;
                btnrecordVideo.IsEnabled = false;
                btnstopVideo.IsEnabled = false;
            }
        }

        private void CaptureImage(object sender, EventArgs e)
        {
            cameraView.Shutter();
        }

        private void RecordVideo(object sender, EventArgs e)
        {
            cameraView.Shutter();
        }

        private void StopVideo(object sender, EventArgs e)
        {
            cameraView.Shutter();
        }
    }
}