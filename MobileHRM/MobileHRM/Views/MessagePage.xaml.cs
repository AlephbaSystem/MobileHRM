using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.ViewModel;
using Plugin.AudioRecorder;
using System.IO;
using MobileHRM.Models.Api;
using MobileHRM.Models;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        public MessagesVm Vm;
        private readonly AudioRecorderService audioRecorderService = new AudioRecorderService();
        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        private List<AudioRecorderService> ShowVoice = new List<AudioRecorderService>();
        public MessagePage(Group item)
        {
            Vm = new MessagesVm(item.id);
            InitializeComponent();
            BindingContext = Vm;
            group = item;
            title.Text = group.name;
        }
        Group group;
        //Make Frame for messagae and voice  *******************************//
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(messageEntry.Text))
            {
                var message = new Message { createdAt = DateTime.Now, message = messageEntry.Text, userId = User.UserId, messagesGroupId = group.id, };
                Vm.sendMessage(message);
            }
            Vm.intialize();
            MakeFrame();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            messagelayout.Children.Clear();
            Vm.intialize();
            await MakeFrame();
        }
        private Task MakeFrame()
        {
            foreach (var item in Vm.Items)
            {
                Frame frm = new Frame();
                if (User.UserId == item.userId)
                {
                    frm.BackgroundColor = Color.FromHex("#1A1C23");
                    frm.Margin = new Thickness(5, 0, 70, 0);
                }
                else
                {
                    frm.Margin = new Thickness(70, 0, 5, 0);
                    frm.BackgroundColor = Color.FromHex("#8D8D8D");
                }
                frm.CornerRadius = 20;
                Label lbl = new Label();
                lbl.Text = item.message;
                lbl.TextColor = Color.White;
                lbl.FontSize = 14;
                lbl.VerticalTextAlignment = TextAlignment.Center;
                lbl.HorizontalTextAlignment = TextAlignment.Start;
                frm.Content = lbl;
                messagelayout.Children.Add(frm);
            }
            return Task.CompletedTask;
        }
        //*****************************************************************//

        // Record the voice ***********************************************//

        private async void TapGestureRecognizer_Tapped_recorder(object sender, EventArgs e)
        {
            if (ShowVoice.Count > 0 && ShowVoice[ShowVoice.Count - 1].IsRecording)
            {
                await voicefrm.ScaleTo(1);
                await ShowVoice.Last().StopRecording();
            }
            else
            {
                await voicefrm.ScaleTo(1.3, 100);

                //voicefrm.BackgroundColor = Color.White;
                //ShowVoice.Add(new AudioRecorderService());
                //string m = "s";
                //m += ShowVoice.Count();
                //ShowVoice.Last().FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{m}.wav");
                //await ShowVoice.Last().StartRecording();
            }
        }

        //public async void makeVoiceFrame()
        //{
        //    voicefrm.BackgroundColor = Color.FromHex("272B35");


        //    Frame f = new Frame();
        //    ImageButton ImgPlayer = new ImageButton();
        //    ImgPlayer.Source = "playbuttonarrowhead.png";
        //    ImgPlayer.Margin = new Thickness(15);
        //    ImgPlayer.Padding = new Thickness(0);
        //    ImgPlayer.VerticalOptions = LayoutOptions.CenterAndExpand;
        //    ImgPlayer.HorizontalOptions = LayoutOptions.EndAndExpand;
        //    ImgPlayer.BackgroundColor = Color.Transparent;
        //    ImgPlayer.WidthRequest = 30;
        //    ImgPlayer.HeightRequest = 30;
        //    f.CornerRadius = 10;
        //    f.Padding = new Thickness(0);
        //    ImgPlayer.Clicked += new EventHandler(test);
        //    f.Content = ImgPlayer;
        //    if (item)
        //    {
        //        f.BackgroundColor = Color.FromHex("#1A1C23");
        //        f.Margin = new Thickness(5, 0, 70, 0);
        //    }
        //    else
        //    {
        //        f.Margin = new Thickness(70, 0, 5, 0);
        //        f.BackgroundColor = Color.FromHex("#8D8D8D");
        //    }
        //    messagelayout.Children.Add(f);
        //    ImgPlayer.CommandParameter = ShowVoice.Last().GetAudioFilePath();
        //}
        // *************************************************************************//

        // Show and Play the voice ************************************************//
        private void test(object sender, EventArgs e)
        {
            var t = sender as ImageButton;
            var voice = (string)t.CommandParameter;

            audioPlayer.Play(voice);
        }

        //***********************************************************************//
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }
    }
}