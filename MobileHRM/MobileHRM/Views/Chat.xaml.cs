using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.ViewModels;
using Plugin.AudioRecorder;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chat3 : ContentPage
    {
        public MessagesVm Vm = new MessagesVm();
        private readonly AudioRecorderService audioRecorderService = new AudioRecorderService();
        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        private List<AudioRecorderService> ShowVoice = new List<AudioRecorderService>();
        public chat3()
        {
            InitializeComponent();
            BindingContext = Vm;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(msgentry.Text))
            {
                var itm = new Models.MessageItem
                {
                    Text = msgentry.Text,
                    Time = DateTime.Now,
                    To = "1",
                    From = "2",
                    IsMessageYours = sw.IsToggled,
                };

                MakeFrame(itm);
                Vm.MyMessage.Add(itm);
            }
            Vm.MyMessage = Vm.MyMessage;
            msgentry.Text = "";

        }
        private void MakeFrame(Models.MessageItem Msg)
        {
            Frame frm = new Frame();
            if (Msg.IsMessageYours)
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
            lbl.Text = Msg.Text;
            lbl.TextColor = Color.White;
            lbl.FontSize = 14;
            //lbl.FontFamily = "Quicksand";
            lbl.VerticalTextAlignment = TextAlignment.Center;
            lbl.HorizontalTextAlignment = TextAlignment.Start;
            frm.Content = lbl;
            StacklayoutMsg.Children.Add(frm);
        }

        private async void TapGestureRecognizer_Tapped_recorder(object sender, EventArgs e)
        {
            if (ShowVoice.Count > 0 && ShowVoice[ShowVoice.Count - 1].IsRecording)
            {
                await voicefrm.ScaleTo(1);
                voicefrm.BackgroundColor = Color.FromHex("272B35");
                await ShowVoice.Last().StopRecording();

                Frame f = new Frame();
                ImageButton ImgPlayer = new ImageButton();
                ImgPlayer.Source = "playbuttonarrowhead.png";
                ImgPlayer.Margin= new Thickness(15);
                ImgPlayer.Padding= new Thickness(0);
                
                ImgPlayer.VerticalOptions = LayoutOptions.CenterAndExpand;
                ImgPlayer.HorizontalOptions = LayoutOptions.EndAndExpand;
                ImgPlayer.BackgroundColor = Color.Transparent;
                f.CornerRadius = 10;
                f.Padding= new Thickness(0);
                ImgPlayer.Clicked += new EventHandler(test);
                f.Content = ImgPlayer;
                var itm = new Models.MessageItem
                {
                    Text = msgentry.Text,
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
                StacklayoutMsg.Children.Add(f);
                ImgPlayer.CommandParameter = ShowVoice.Last();
                audioPlayer.Play(audioRecorderService.GetAudioFilePath());
            }
            else
            {

                await voicefrm.ScaleTo(1.3, 100);
                voicefrm.BackgroundColor = Color.White;
                ShowVoice.Add(new AudioRecorderService());
                await ShowVoice.Last().StartRecording();
            }

        }
        private void test(object sender, EventArgs e)
        {
            var t = sender as ImageButton;
            var voice = (AudioRecorderService)t.CommandParameter;
            audioPlayer.Play(voice.GetAudioFilePath());
        }
    }
}