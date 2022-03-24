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
        AudioPlayer audioplayer = new AudioPlayer();
        public MessagesVm(int _GroupId)
        {
            GroupId = _GroupId;
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

        private string currentAudio { get; set; } = string.Empty;
        private bool IsPlaying { get; set; } = false; //true of false eather Audio Is Is Playing or not        
    }
}