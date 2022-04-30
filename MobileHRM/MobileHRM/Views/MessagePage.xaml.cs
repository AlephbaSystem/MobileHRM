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
using MobileHRM.Views.Popup;
using Rg.Plugins.Popup.Services;
using Grpc.Core;
using System.Net;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        private readonly MessagesVm Vm;
        private readonly Models.Entities.GroupModel group;
        //private readonly AudioRecorderService audioRecorderService = new AudioRecorderService();
        private AudioRecorderService ShowVoice;

        public MessagePage(Models.Entities.GroupModel item1)
        {
            InitializeComponent();
            Vm = new MessagesVm(item1.id, item1.image, item1.ownerId);
            BindingContext = Vm;
            group = item1;
            title.Text = group.name;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            loading.IsVisible = loading.IsRunning = true;
            await Vm.intialize();
            List<GroupMessage> itm = Vm.Items;
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
            View lastchild = messagelayout.Children.LastOrDefault();
            if (lastchild != null)
            {
                await scrollview.ScrollToAsync(lastchild, ScrollToPosition.MakeVisible, true);
            }
        }

        private Task addmessage()
        {
            messagelayout.Children.Clear();
            if (Vm.Items.Count == 0)
            {
                return Task.CompletedTask;
            }
            if (Vm.Items[0].createdAt.Day == DateTime.Now.Day)
            {
                messagelayout.Children.Add(new Label
                {
                    TextColor = Color.Silver,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = "Today"
                });
            }
            else
            {
                messagelayout.Children.Add(new Label
                {
                    TextColor = Color.Silver,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = Vm.Items[0].createdAt.ToString("dd MMMM")
                });
            }
            for (int i = 0; i < Vm.Items.Count; i++)
            {
                if (i > 0 && Vm.Items[i].createdAt.Day != Vm.Items[i - 1].createdAt.Day)
                {
                    if (Vm.Items[i].createdAt.Day == DateTime.Now.Day)
                    {
                        messagelayout.Children.Add(new Label
                        {
                            TextColor = Color.Silver,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            Text = "Today"
                        });
                    }
                    else
                    {
                        messagelayout.Children.Add(new Label
                        {
                            TextColor = Color.Silver,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            Text = Vm.Items[i].createdAt.ToString("dd MMMM")
                        });
                    }
                }
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
            return date.ToLocalTime().ToString("hh: mm");
        }

        private void MakeImageFrame(GroupMessage item)
        {
            Frame frm = new Frame
            {
                Padding = new Thickness(0),
                CornerRadius = 30,
            };
            Label timelabel = new Label
            {
                Text = DateConveter(item.createdAt),
                FontSize = 8,
                TextColor = Color.Silver,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Margin = new Thickness(30, 0, 30, 10)
            };
            TapGestureRecognizer gesture = new TapGestureRecognizer();
            gesture.Tapped += Message_Tapped;
            gesture.CommandParameter = item;
            frm.GestureRecognizers.Add(gesture);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"Image-{item.createdAt.ToString("yyyy_MM_dd__HH_mm_ss")}.jpg"; //ImagePath
            frm.AutomationId = path;
            Image imageFile = new Image
            {
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 80,
                HeightRequest = 80,
                Margin = new Thickness(0),
            };
            ActivityIndicator Downloadactivate = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsRunning = false
            };
            if (User.UserId == item.userId)
            {
                frm.Margin = new Thickness(5, 5, 70, 5);
                frm.BackgroundColor = Color.FromHex("#1A1C23");
            }
            else
            {
                frm.Margin = new Thickness(70, 5, 5, 5);
                frm.BackgroundColor = Color.FromHex("#EBEBEB");
                timelabel.TextColor = Color.Black;

                imageFile.HorizontalOptions = LayoutOptions.EndAndExpand;
            }

            if (File.Exists(path))
            {
                imageFile.Source = ImageSource.FromFile(path);
            }
            else
            {
                imageFile.Source = "ChessBoard.png";
            }
            StackLayout stack = new StackLayout();
            var layout = new Grid { ColumnDefinitions = new ColumnDefinitionCollection() { new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }, new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }, new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) } } };
            Grid.SetColumn(imageFile, 0);
            Grid.SetColumn(Downloadactivate, 0);
            layout.Children.Add(imageFile);
            layout.Children.Add(Downloadactivate);
            stack.Children.Add(layout);
            stack.Children.Add(timelabel);
            frm.Content = stack;
            messagelayout.Children.Add(frm);
        }

        private async void Message_Tapped(object sender, EventArgs e)
        {
            Frame Layout = (sender as Frame);
            var data = (GroupMessage)(Layout.GestureRecognizers[0] as TapGestureRecognizer).CommandParameter;
            if (!File.Exists(Layout.AutomationId))
            {
                ((ActivityIndicator)((Layout.Content as StackLayout).Children[0] as Grid).Children[1]).IsRunning = true;
                data.media = await Vm.GetMediaByMediaId(data.mediaId);
                (Layout.GestureRecognizers[0] as TapGestureRecognizer).CommandParameter = data;
                var imageSource = DataConverter.SaveImageByByte(data.media, data.createdAt);
                ((Image)((Layout.Content as StackLayout).Children[0] as Grid).Children[0]).Source = imageSource;
                ((ActivityIndicator)((Layout.Content as StackLayout).Children[0] as Grid).Children[1]).IsRunning = false;
            }
        }

        private void MakeFrame(GroupMessage item)
        {
            Frame frm = new Frame { Padding = new Thickness(10, 5) };
            Label timelabel = new Label
            {
                Text = DateConveter(item.createdAt),
                FontSize = 8,
                TextColor = Color.Silver,
                HorizontalTextAlignment = TextAlignment.End,
                Margin = new Thickness(30, 0, 30, 10)
            };
            Thickness pad = timelabel.Padding;
            pad.Top += 2;
            timelabel.Padding = pad;
            frm.CornerRadius = 30;
            Label lbl = new Label
            {
                Text = item.message,
                TextColor = Color.White,
                FontSize = 14,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start
            };
            if (User.UserId == item.userId)
            {
                frm.BackgroundColor = Color.FromHex("#1A1C23");
                frm.Margin = new Thickness(5, 0, 70, 0);
            }
            else
            {
                timelabel.HorizontalTextAlignment = TextAlignment.End;
                frm.Margin = new Thickness(70, 0, 5, 0);
                frm.BackgroundColor = Color.FromHex("#EBEBEB");
                timelabel.TextColor = Color.Black;
                lbl.TextColor = Color.Black;
            }
            frm.CornerRadius = 20;
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
                voicefrm.BackgroundColor = Color.FromHex("272B35");
                await voicefrm.ScaleTo(1);
                await ShowVoice.StopRecording();
                Message message = new Message
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
                if (await Permissions.CheckStatusAsync<Permissions.Microphone>() != PermissionStatus.Granted)
                {
                    var status = await Permissions.RequestAsync<Permissions.Microphone>();
                    if (status == PermissionStatus.Denied)
                        return;
                }
                await voicefrm.ScaleTo(1.3, 100);
                voicefrm.BackgroundColor = Color.White;
                ShowVoice = new AudioRecorderService();
                await ShowVoice.StartRecording();
            }
        }

        public void makeVoiceFrame(GroupMessage msg)
        {
            ImageButton ImgPlayer = new ImageButton
            {
                Source = "playbuttonarrowhead.png",
                Margin = new Thickness(15),
                Padding = new Thickness(0),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                BackgroundColor = Color.Transparent,
                WidthRequest = 25,
                HeightRequest = 25
            };
            ImgPlayer.Clicked += new EventHandler(Vm.PlayVoice);
            Grid grid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection() { new ColumnDefinition(), new ColumnDefinition(), new ColumnDefinition() }
            };
            Frame f = new Frame
            {
                CornerRadius = 30,
                Padding = new Thickness(0),
                Content = ImgPlayer,
                HeightRequest = 70
            };
            Label timelabel = new Label
            {
                Text = DateConveter(msg.createdAt),
                FontSize = 8,
                TextColor = Color.Silver,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(5, 0, 0, 10)
            };
            Grid Grid = new Grid { ColumnDefinitions = new ColumnDefinitionCollection() { new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) }, new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) } } };
            Slider slider = new Slider { ThumbColor = Color.FromHex("00A693"), VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            Grid.SetColumn(ImgPlayer, 1);
            Grid.SetColumn(timelabel, 1);
            Grid.SetColumn(slider, 0);
            Grid.Children.Add(ImgPlayer);
            Grid.Children.Add(timelabel);
            Grid.Children.Add(slider);
            f.Content = Grid;
            if (msg.userId == User.UserId)
            {
                f.BackgroundColor = Color.FromHex("#1A1C23");
                f.Margin = new Thickness(5, 0, 70, 0);
            }
            else
            {
                f.Margin = new Thickness(70, 0, 5, 0);
                f.BackgroundColor = Color.FromHex("#EBEBEB");
                timelabel.TextColor = Color.Black;
            }
            messagelayout.Children.Add(f);
            ImgPlayer.Clicked += Vm.PlayVoice;
            ImgPlayer.CommandParameter = msg;
            ImgPlayer.AutomationId = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"Audio-{msg.createdAt.ToString("yyyy_MM_dd__HH_mm_ss")}.wav";
        }

        //***********************************************************************//
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Vm.RunIsBusyTaskAsync(async () =>
            {
                try
                {
                    var photo = await MediaPicker.CapturePhotoAsync();
                    // canceled
                    if (photo == null)
                    {
                        return;
                    }
                    Message message = new Message
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
            });
        }


        private async void DeleteGroip_Tapped_(object sender, EventArgs e)
        {
            await Vm.RunIsBusyTaskAsync(async () =>
            {
                if (await DisplayAlert("Warning!", "Group Will Delete Are You Sure?", "Ok", "Cancel"))
                {
                    Vm.DeleteGroup();
                    await Navigation.PopAsync();
                }
            });
        }

        private async void more_Clicked(object sender, EventArgs e)
        {
            await Vm.RunIsBusyTaskAsync(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new Messages_Edit(new Models.Entities.Group { id = group.id, name = group.name, image = group.image, ownerId = group.ownerId }));
            }
            );
        }
    }
}