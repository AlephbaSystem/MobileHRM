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
        MobileHRM.Models.Entities.GroupModel group;
        private readonly AudioRecorderService audioRecorderService = new AudioRecorderService();
        private AudioRecorderService ShowVoice;
        public MessagePage(MobileHRM.Models.Entities.GroupModel item)
        {
            InitializeComponent();
            Vm = new MessagesVm(item.id, item.image,item.ownerId);
            BindingContext = Vm;
            group = item;
            title.Text = group.name;
        }
        //Make Frame for messagae and voice  *******************************//
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(messageEntry.Text))
            {
                var message = new Message { updateAt = DateTime.Now, createdAt = DateTime.Now, message = messageEntry.Text, userId = User.UserId, messagesGroupId = group.id, media = new byte[1], mediaType = "", };
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
            Vm.InsertMessageSeen(group.unSeenedMessages);
            group.unSeenedMessages = 0;
            loading.IsVisible = loading.IsRunning = false;
        }
        private Task addmessage()
        {
            messagelayout.Children.Clear();
            for (int i = 0; i < Vm.Items.Count; i++)
            {
                if (Vm.Items[i].mediaType == "Voice")
                {
                    makeVoiceFrame(Vm.Items[i]);
                }
                else if (Vm.Items[i].mediaType == "Image")
                {
                    MakeImageFrame(Vm.Items[i]);
                }
                else
                    MakeFrame(Vm.Items[i]);
            }
            return Task.CompletedTask;
        }
        private void MakeImageFrame(GroupMessage item) //MakeMessageFrame
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
            var source = DataConverter.SaveImageByByte(item.media);
            Image lbl = new Image { Aspect = Aspect.AspectFit, Source = source, HorizontalOptions = LayoutOptions.FillAndExpand };
            var stack = new StackLayout();
            stack.Children.Add(lbl);
            stack.Children.Add(timelabel);
            frm.Content = stack;
            messagelayout.Children.Add(frm);
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
            if (ShowVoice != null && ShowVoice.IsRecording)
            {
                await voicefrm.ScaleTo(1);
                await ShowVoice.StopRecording();
                var message = new Message { updateAt = DateTime.Now, createdAt = DateTime.Now, message = "Voice", userId = User.UserId, messagesGroupId = group.id, mediaType = "Voice" };
                using (var stream = ShowVoice.GetAudioFileStream())
                {
                    message.media = new byte[(int)stream.Length];
                    await stream.ReadAsync(message.media, 0, (int)stream.Length);
                }
                await Vm.sendMessage(message);
                await Vm.intialize();
                addmessage();
                ShowVoice = null;
            }
            else
            {
                await voicefrm.ScaleTo(1.3, 100);
                voicefrm.BackgroundColor = Color.White;
                ShowVoice = new AudioRecorderService();
                string m = "s";
                await ShowVoice.StartRecording();
            }
        }
        public async void makeVoiceFrame(GroupMessage msg)
        {
            var path = DataConverter.SaveAudioByByte(msg.media);
            if (path == null)
            {
                await DisplayAlert("Error", "An Error Ocurred", "Back");
                return;
            }
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
            ImgPlayer.Clicked += new EventHandler(Vm.PlayVoice);
            f.Content = ImgPlayer;
            if (msg.userId == User.UserId)
            {
                f.BackgroundColor = Color.FromHex("#1A1C23");
                f.Margin = new Thickness(5, 0, 70, 0);
            }
            else
            {
                f.Margin = new Thickness(70, 0, 5, 0);
                f.BackgroundColor = Color.FromHex("#8D8D8D");
            }
            messagelayout.Children.Add(f);

            ImgPlayer.CommandParameter = path;
        }
        // *************************************************************************//

        KnowledgeApi Reqest = new KnowledgeApi();
        //***********************************************************************//
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                // canceled
                if (photo == null)
                {
                    return;
                }
                var message = new Message { updateAt = DateTime.Now, createdAt = DateTime.Now, message = "Photo", userId = User.UserId, messagesGroupId = group.id, mediaType = "Image" };
                //byte[] fileBytes = File.ReadAllBytes(photo.FullPath);
                using (Stream stream = await photo.OpenReadAsync())
                {
                    message.media = new byte[(int)stream.Length];
                    await stream.ReadAsync(message.media, 0, (int)stream.Length);
                }
                await Vm.sendMessage(message);
                await Vm.intialize();
                addmessage();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        private async void DeleteGroip_Tapped_(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning!", "Group Will Delete Are You Sure?","Ok", "Cancel"))
            {
                Vm.DeleteGroup();
                await Task.Delay(1000);
                await Navigation.PopAsync();
            }            
        }
    }
}