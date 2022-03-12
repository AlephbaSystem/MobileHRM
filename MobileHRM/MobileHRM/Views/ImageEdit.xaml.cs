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
    public partial class ImageEdit : ContentPage
    {
        public string ImgAddres{
            get;
            private set;
        }
        public ImageEdit(ImageSource imgAdd)
        {
            InitializeComponent();
            imgEdit.Source = imgAdd;
            
        }

        public void rotateImg()
        {
            imgEdit.Rotate();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            imgEdit.Rotate();

        }

        private void imgEdit_ImageSaved(object sender, Syncfusion.SfImageEditor.XForms.ImageSavedEventArgs args)
        {
            ImgAddres = args.Location;
        }
    }
}