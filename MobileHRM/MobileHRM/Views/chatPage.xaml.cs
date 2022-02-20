﻿using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chatPage : ContentView
    {
        public chatPage()
        {
            InitializeComponent();
            tempData();
        }

        async void tempData()
        {
            List<tempDatas> list = new List<tempDatas>
           {
               new tempDatas { NameUser= "userImage.png" ,SubTitle ="alialialialialialialialialiali", Time="mas", Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle="mamadmamadmamadmamadmamadmamadm", Time="adi",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle ="alialialialialialialialialiali", Time="mas",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle ="alialialialialialialialialiali", Time="mas",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle ="alialialialialialialialialiali", Time="sho",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle="alialialialialialialialialialir", Time="mashh",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle ="alialialialialialialialialiali", Time="masdi",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle ="alialialialialialialialialiali", Time="masdi",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle="mamadmamadmamadmamadmamadmaamad", Time="hhadi",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle="alialialialialialialialialirali", Time="mashh",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle ="alialialialialialialialialiali", Time="masdi",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle ="alialialialialialialialialiali", Time="masdi",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle="mamadmamadmamadmamadmamaadmamad", Time="hhadi",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle="alialialialialialialialiraliali", Time="mashh",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle ="alialialialialialialialialiali", Time="masdi",Number="2"},
               new tempDatas { NameUser= "userImage.png" ,SubTitle="mamadmamadmamadmamadmmamadmamad", Time="hhadi",Number="2"}
           };
            await Task.Run(() =>
            {
                CollectionChat.ItemsSource = list;
            });
        }
        public class tempDatas
        {
            public string NameUser { get; set; }
            public string SubTitle { get; set; }
            public string Time { get; set; }
            public string Number { get; set; }
        }

    }
}