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
        Models.Entities.GroupModel group;
        //private readonly AudioRecorderService audioRecorderService = new AudioRecorderService();
        private AudioRecorderService ShowVoice;

        public MessagePage(Models.Entities.GroupModel item)
        {
            InitializeComponent();
            Vm = new MessagesVm(item.id, item.image, item.ownerId);
            BindingContext = Vm;
            group = item;
            title.Text = group.name;
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


        //Make Frame for messagae and voice  *******************************//
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(messageEntry.Text))
            {
                Message message = new Message
                {
                    updateAt = DateTime.Now,
                    createdAt = DateTime.Now,
                    message = messageEntry.Text,
                    userId = User.UserId,
                    messagesGroupId = group.id,
                    media = new byte[1],
                    mediaType = ""
                };
                messageEntry.Text = string.Empty;
                await Vm.sendMessage(message);
                await Vm.intialize();
                await addmessage();
            }
            var lastchild = messagelayout.Children.LastOrDefault();
            if (lastchild != null)
            {
                await scrollview.ScrollToAsync(lastchild, ScrollToPosition.MakeVisible, true);
            }
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


        private string DateConveter(DateTime date)
        {
            if (date.Day != DateTime.Now.Day)
            {
                return date.ToLocalTime().ToString("hh: mm");
            }
            else
            {
                return date.ToLocalTime().ToString("dd MMMM yyyy");
            }
        }


        private void MakeImageFrame(GroupMessage item)
        {
            Frame frm = new Frame
            {
                Padding = new Thickness(0),
                CornerRadius = 20
            };
            Label timelabel = new Label
            {
                Text = DateConveter(item.createdAt),
                FontSize = 8,
                TextColor = Color.Silver,
                HorizontalTextAlignment = TextAlignment.End,
                Margin=new Thickness(30,0,30,10)
            };
            var pad = timelabel.Padding;
            pad.Top += 2;
            timelabel.Padding = pad;
            if (User.UserId == item.userId)
            {
                frm.Margin = new Thickness(5, 15, 70, 15);
                frm.BackgroundColor = Color.FromHex("#1A1C23");
            }
            else
            {
                //timelabel.HorizontalTextAlignment = TextAlignment.End;
                frm.Margin = new Thickness(70, 15, 5, 15);
                frm.BackgroundColor = Color.FromHex("#8D8D8D");
            }
            
            var source = DataConverter.SaveImageByByte(item.media);
            Image imageFile = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = source,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            StackLayout stack = new StackLayout();
            stack.Children.Add(imageFile);
            stack.Children.Add(timelabel);
            frm.Content = stack;
            messagelayout.Children.Add(frm);
        }


        private void MakeFrame(GroupMessage item)
        {
            Frame frm = new Frame();
            var timelabel = new Label
            {
                Text = DateConveter(item.createdAt),
                FontSize = 8,
                TextColor = Color.Silver,
                HorizontalTextAlignment = TextAlignment.End,
                Margin = new Thickness(30, 0, 30, 10)
            };
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
            Label lbl = new Label
            {
                Text = item.message,
                TextColor = Color.White,
                FontSize = 14,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start
            };
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
                var message = new Message
                {
                    updateAt = DateTime.Now,
                    createdAt = DateTime.Now,
                    message = "Voice",
                    userId = User.UserId,
                    messagesGroupId = group.id,
                    mediaType = "Voice"
                };
                using (var stream = ShowVoice.GetAudioFileStream())
                {
                    message.media = new byte[(int)stream.Length];
                    await stream.ReadAsync(message.media, 0, (int)stream.Length);
                }
                await Vm.sendMessage(message);
                await Vm.intialize();
                await addmessage();
                ShowVoice = null;
            }
            else
            {
                await voicefrm.ScaleTo(1.3, 100);
                voicefrm.BackgroundColor = Color.White;
                ShowVoice = new AudioRecorderService();
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
            ImageButton ImgPlayer = new ImageButton
            {
                Source = "playbuttonarrowhead.png",
                Margin = new Thickness(15),
                Padding = new Thickness(0),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                BackgroundColor = Color.Transparent,
                WidthRequest = 30,
                HeightRequest = 30
            };
            ImgPlayer.Clicked += new EventHandler(Vm.PlayVoice);
            Frame f = new Frame
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                Content = ImgPlayer
            };

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
                var message = new Message
                {
                    updateAt = DateTime.Now,
                    createdAt = DateTime.Now,
                    message = "Photo",
                    userId = User.UserId,
                    messagesGroupId = group.id,
                    mediaType = "Image"
                };
                //byte[] fileBytes = File.ReadAllBytes(photo.FullPath);
                using (Stream stream = await photo.OpenReadAsync())
                {
                    message.media = new byte[(int)stream.Length];
                    await stream.ReadAsync(message.media, 0, (int)stream.Length);
                }
                await Vm.sendMessage(message);
                await Vm.intialize();
                await addmessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }


        private async void DeleteGroip_Tapped_(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning!", "Group Will Delete Are You Sure?", "Ok", "Cancel"))
            {
                Vm.DeleteGroup();
                await Navigation.PopAsync();
            }
        }




        //*****************************************************************

       



        }
}