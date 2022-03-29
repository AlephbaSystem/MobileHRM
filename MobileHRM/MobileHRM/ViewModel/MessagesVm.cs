using MobileHRM.Api;
using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MobileHRM.Models;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.AudioRecorder;

namespace MobileHRM.ViewModel
{
    public class MessagesVm : Base
    {
        private int GroupId;
        private ImageSource _Profileimage;
        public ImageSource Profileimage
        {
            get
            {
                return _Profileimage;
            }
            set
            {
                _Profileimage = value;
                OnPropertyChanged(nameof(Profileimage));
            }
        }
        private bool _IsGroupOwner;
        public bool IsGroupOwner
        {
            get
            {
                return _IsGroupOwner;
            }
            set
            {
                _IsGroupOwner = value;
                OnPropertyChanged(nameof(IsGroupOwner));
            }
        }

        AudioPlayer audioplayer = new AudioPlayer();
        public MessagesVm(int _GroupId, ImageSource _image,int userId)
        {
            GroupId = _GroupId;
            if (userId == User.UserId)
            {
                IsGroupOwner = true;
            }
            else
            {
                IsGroupOwner = false;
            }
            Profileimage = _image;
        }
        private List<GroupMessage> _items;
        public List<GroupMessage> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        ChatApi request = new ChatApi();
        public async Task intialize()
        {
            try
            {
                var item = await request.GetMessageByGroupId(GroupId, 0, 20);
                Items = item ?? new List<GroupMessage>();
            }
            catch (Exception e)
            {
                Items = new List<GroupMessage>();
                throw;
            }
        }
        public async Task<bool> sendMessage(Message msg)
        {
            return await request.SendMessage(msg);
        }
        private ObservableCollection<MessageItem> _myMessage { get; set; }

        public void PlayVoice(object sender, EventArgs e)
        {
            if (IsPlaying)
            {
                audioplayer.Pause();
                audioplayer = new AudioPlayer();
                IsPlaying = false;
            }
            var t = sender as ImageButton;
            var Audio = (string)t.CommandParameter;
            if (Audio == currentAudio)
            {
                currentAudio = string.Empty;
                return;
            }
            currentAudio = Audio;
            audioplayer.FinishedPlaying += Audioplayer_FinishedPlaying;
            audioplayer.Play(Audio);
            IsPlaying = true;
        }

        private void Audioplayer_FinishedPlaying(object sender, EventArgs e)
        {
            IsPlaying = false;
            currentAudio = string.Empty;
        }
        public async void DeleteGroup()
        {
            await request.DeleteGroupByGroupId(GroupId);
        }
        private string currentAudio { get; set; } = string.Empty;
        private bool IsPlaying { get; set; } = false; //true of false eather Audio Is Is Playing or not        
        public async void InsertMessageSeen(int UnSeenedMessageConut)
        {
            if (Items.Count == 0)
            {
                return;
            }
            List<Models.Entities.Request.MessageSeen> itms = new List<Models.Entities.Request.MessageSeen>();
            for (int i = Items.Count - 1; i >= Items.Count - UnSeenedMessageConut; i--)
            {
                itms.Add(new Models.Entities.Request.MessageSeen { messageId = Items[i].id, userId = User.UserId });
            }
            if (itms.Count > 0)
            {
                await request.InsertMessageSeen(itms);
            }
        }
    }
}