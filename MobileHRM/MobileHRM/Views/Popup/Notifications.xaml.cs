using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notifications : PopupPage
    {
        public Notifications()
        {
            InitializeComponent();
            tempData();
        }

        async void tempData()
        {
            List<tempDatas> list = new List<tempDatas>
           {
               new tempDatas { image= "orangeTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "greenTik.png" ,title ="mamadmamadmamadmamadmamadmamadmamad", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "orangeTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "orangeTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "orangeTik.png" ,title ="alialialialialialialialialiali", subTitle="shomalshomalshomalshomalshomalshomal"},
               new tempDatas { image= "greenTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "orangeTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "orangeTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "greenTik.png" ,title ="mamadmamadmamadmamadmamadmamadmamad", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "greenTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "orangeTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "orangeTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "greenTik.png" ,title ="mamadmamadmamadmamadmamadmamadmamad", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "greenTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "orangeTik.png" ,title ="alialialialialialialialialiali", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"},
               new tempDatas { image= "greenTik.png" ,title ="mamadmamadmamadmamadmamadmamadmamad", subTitle="mashhadimashhadimashhadimashhadimashhadimashhadi"}
           };
            await Task.Run(() =>
            {
                collectionNotification.ItemsSource = list;
            });
        }

        private async void OnCloseImageButtonClicked(object sender, EventArgs e)
        {
            Animation animation = new Animation(v => ImageExitNotification.Scale = v, 0.8, 1.3, Easing.SinInOut);
            animation.Commit(ImageExitNotification, "animate", 20, 200, Easing.SinIn);
            await ImageExitNotification.ScaleTo(1, 200, Easing.SinIn);
            await PopupNavigation.Instance.PopAsync();
        }
    }
    public class tempDatas
    {
        public string title { get; set; }
        public string subTitle { get; set; }
        public ImageSource image { get; set; }
    }
}