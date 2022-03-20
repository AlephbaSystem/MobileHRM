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
using System.Threading.Tasks;
using MobileHRM.Helper;
using System.Reflection;
using Xamarin.Essentials;
using MobileHRM.Api;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        private MessagesVm Vm;
        Group group;
        private readonly AudioRecorderService audioRecorderService = new AudioRecorderService();
        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        private List<AudioRecorderService> ShowVoice = new List<AudioRecorderService>();
        public MessagePage(Group item)
        {
            InitializeComponent();
            Vm = new MessagesVm(item.id);
            BindingContext = Vm;
            group = item;
            title.Text = group.name;
        }
        //Make Frame for messagae and voice  *******************************//
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(messageEntry.Text))
            {
                var message = new Message { updateAt = DateTime.Now, createdAt = DateTime.Now, message = messageEntry.Text, userId = User.UserId, messagesGroupId = group.id, };
                messageEntry.Text = string.Empty;
                await Vm.sendMessage(message);
                await Vm.intialize();
                addmessage();
            }
            var lastchild = messagelayout.Children.LastOrDefault();
            if (lastchild != null)
            {
                await scrollview.ScrollToAsync(lastchild, ScrollToPosition.MakeVisible, true);
            }

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            loading.IsVisible = loading.IsRunning = true;
            await Vm.intialize();
            var itm = Vm.Items;
            if (itm != null)
            {
                await addmessage();
            }
            loading.IsVisible = loading.IsRunning = false;
        }
        private Task addmessage()
        {
            messagelayout.Children.Clear();
            foreach (GroupMessage item in Vm.Items)
            {
                MakeFrame(item);
            }
            return Task.CompletedTask;
        }
        private void MakeFrame(GroupMessage item) //MakeMessageFrame
        {

            Frame frm = new Frame();
            var timelabel = new Label { Text = item.createdAt.ToString(), FontSize = 8, TextColor = Color.Silver, HorizontalTextAlignment = TextAlignment.Start };
            var pad = timelabel.Padding;
            pad.Top += 2;
            timelabel.Padding = pad;
            if (User.UserId == item.userId)
            {
                frm.BackgroundColor = Color.FromHex("#1A1C23");
                frm.Margin = new Thickness(5, 0, 70, 0);
            }
            else
            {
                timelabel.HorizontalTextAlignment = TextAlignment.End;
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
            var stack = new StackLayout();
            stack.Children.Add(lbl);
            stack.Children.Add(timelabel);
            frm.Content = stack;
            messagelayout.Children.Add(frm);
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

                voicefrm.BackgroundColor = Color.White;
                ShowVoice.Add(new AudioRecorderService());
                string m = "s";
                m += ShowVoice.Count();
                ShowVoice.Last().FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{m}.wav");
                await ShowVoice.Last().StartRecording();
            }
        }

        public async void makeVoiceFrame()
        {
            voicefrm.BackgroundColor = Color.FromHex("272B35");
            Frame f = new Frame();
            ImageButton ImgPlayer = new ImageButton();
            ImgPlayer.Source = "playbuttonarrowhead.png";
            ImgPlayer.Margin = new Thickness(15);
            ImgPlayer.Padding = new Thickness(0);
            ImgPlayer.VerticalOptions = LayoutOptions.CenterAndExpand;
            ImgPlayer.HorizontalOptions = LayoutOptions.EndAndExpand;
            ImgPlayer.BackgroundColor = Color.Transparent;
            ImgPlayer.WidthRequest = 30;
            ImgPlayer.HeightRequest = 30;
            f.CornerRadius = 10;
            f.Padding = new Thickness(0);
            ImgPlayer.Clicked += new EventHandler(test);
            f.Content = ImgPlayer;
            //if (true)
            {
                f.BackgroundColor = Color.FromHex("#1A1C23");
                f.Margin = new Thickness(5, 0, 70, 0);
            }
            //else
            //{
            //    f.Margin = new Thickness(70, 0, 5, 0);
            //    f.BackgroundColor = Color.FromHex("#8D8D8D");
            //}
            messagelayout.Children.Add(f);
            ImgPlayer.CommandParameter = ShowVoice.Last().GetAudioFilePath();
        }
        // *************************************************************************//

        // Show and Play the voice ************************************************//
        private void test(object sender, EventArgs e)
        {
            var t = sender as ImageButton;
            var voice = (string)t.CommandParameter;
            audioPlayer.Play(voice);
        }
        KnowledgeApi Reqest = new KnowledgeApi();
        //***********************************************************************//
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //try
            //{
            //    var photo = await MediaPicker.CapturePhotoAsync();
            //    // canceled
            //    if (photo == null)
            //    {
            //        return;
            //    }
            //    byte[] fileBytes = File.ReadAllBytes(photo.FullPath);
            //    var reqmodel = new UserProfile { image = fileBytes, userId = 1, userName = "Moein" };
            //    await Reqest.PostImage(reqmodel);
            //}

            //catch (Exception ex)
            //{
            //    Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            //}
        }
    }
}