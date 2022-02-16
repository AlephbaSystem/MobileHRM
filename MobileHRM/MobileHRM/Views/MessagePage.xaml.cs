using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.Models;
using MobileHRM.ViewModels;
using Plugin.AudioRecorder;
using System.IO;
using MobileHRM.Views.customPage;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        string sourseImage;

        public MessagesVm Vm = new MessagesVm();
        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        private List<AudioRecorderService> audioRecorderServices = new List<AudioRecorderService>();

        public MessagePage()
        {
            InitializeComponent();
            BindingContext = Vm;
        }

        private void TapGestureRecognizer_sendMessage(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(messageEntry.Text))
            {
                var itemMessage = new MessageItem
                {
                    Text = messageEntry.Text,
                    Time = DateTime.Now,
                    To = "1",
                    From = "2",
                    IsMessageYours = sw.IsToggled,
                };

                MakeFrame(itemMessage);
                Vm.MyMessage.Add(itemMessage);
            }
            Vm.MyMessage = Vm.MyMessage;
            messageEntry.Text = "";
        }

        private void MakeFrame(MessageItem Message)
        {
            Label lbl = new Label
            {
                Text = Message.Text,
                TextColor = Color.White,
                FontSize = 14,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start
            };

            Frame frm = new Frame
            {
                CornerRadius = 20,
                Content = lbl
            };
            if (Message.IsMessageYours)
            {
                frm.BackgroundColor = Color.FromHex("#1A1C23");
                frm.Margin = new Thickness(5, 0, 70, 0);
            }
            else
            {
                frm.Margin = new Thickness(70, 0, 5, 0);
                frm.BackgroundColor = Color.FromHex("#8D8D8D");
            }

            messagelayout.Children.Add(frm);
        }

        private void MakeVoiceFrame()
        {
            ImageButton ImgPlayer = new ImageButton
            {
                Source = "Dashboard.png",
                Margin = new Thickness(15),
                Padding = new Thickness(0),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                BackgroundColor = Color.Transparent
            };

            ImgPlayer.Clicked += new EventHandler(PlayVoice);

            Frame f = new Frame
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                Content = ImgPlayer
            };

            var itm = new MessageItem
            {
                Text = messageEntry.Text,
                Time = DateTime.Now,
                To = "1",
                From = "2",
                IsMessageYours = sw.IsToggled,
            };

            if (itm.IsMessageYours)
            {
                f.BackgroundColor = Color.FromHex("#1A1C23");
                f.Margin = new Thickness(5, 0, 70, 0);
            }
            else
            {
                f.Margin = new Thickness(70, 0, 5, 0);
                f.BackgroundColor = Color.FromHex("#8D8D8D");
            }

            Vm.MyMessage.Add(itm);
            messagelayout.Children.Add(f);
            ImgPlayer.CommandParameter = audioRecorderServices.Last();
        }



        private async void TapGestureRecognizer_voiceRecorder(object sender, EventArgs e)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var status = await Permissions.RequestAsync<Permissions.Microphone>();
                if (status != PermissionStatus.Granted)
                {
                    return;
                }

                if (audioRecorderServices.Count > 0 && audioRecorderServices[audioRecorderServices.Count - 1].IsRecording)
                {
                    await voicefrm.ScaleTo(1);
                    voicefrm.BackgroundColor = Color.FromHex("272B35");
                    await audioRecorderServices.Last().StopRecording();
                    MakeVoiceFrame();
                    audioPlayer.Play(audioRecorderServices.Last().GetAudioFilePath());
                }
                else
                {
                    await voicefrm.ScaleTo(1.3, 100);
                    voicefrm.BackgroundColor = Color.White;
                    audioRecorderServices.Add(new AudioRecorderService());
                    await audioRecorderServices.Last().StartRecording();
                }
                IsBusy = false;
            }
            //var test = audioRecorderServices.Last();
        }

        private void PlayVoice(object sender, EventArgs e)
        {
            var t = sender as ImageButton;
            var voice = (AudioRecorderService)t.CommandParameter;
            audioPlayer.Play(voice.GetAudioFilePath());            
        }

        private async void TapGestureRecognizer_oppenCamera(object sender, EventArgs e)
        {
            //await TakePhotoAsync();
            //CreateImageMessage();
            if (!IsBusy)
            {
                await Navigation.PushAsync(new CameraPage());
                IsBusy = false;
            }
        }

        //public void CreateImageMessage()
        //{
        //    ImageButton CameraImage = new ImageButton
        //    {
        //        Margin = new Thickness(1),
        //        Padding = new Thickness(0),
        //        VerticalOptions = LayoutOptions.Fill,
        //        HorizontalOptions = LayoutOptions.Fill,
        //        BackgroundColor = Color.Transparent
        //    };
        //    Frame f = new Frame
        //    {
        //        CornerRadius = 10,
        //        Padding = new Thickness(0),
        //        Content = CameraImage
        //    };
        //    var itm = new MessageItem
        //    {
        //        Text = messageEntry.Text,
        //        Time = DateTime.Now,
        //        To = "1",
        //        From = "2",
        //        IsMessageYours = sw.IsToggled,
        //    };
        //    if (itm.IsMessageYours)
        //    {
        //        f.BackgroundColor = Color.FromHex("#1A1C23");
        //        f.Margin = new Thickness(5, 0, 70, 0);
        //    }
        //    else
        //    {
        //        f.Margin = new Thickness(70, 0, 5, 0);
        //        f.BackgroundColor = Color.FromHex("#8D8D8D");
        //    }
        //    CameraImage.Source = sourseImage;
        //    Vm.MyMessage.Add(itm);
        //    messagelayout.Children.Add(f);
        //}
    }
}