using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using MobileHRM.Models.Entities.Request;
using MobileHRM.Api;
using System.Windows.Input;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;

namespace MobileHRM.ViewModel
{
    public class MessageEditViewModel : Base
    {
        Models.Entities.Group _group;
        public Models.Entities.Group Group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
                OnPropertyChanged(nameof(Group));
            }
        }
        public MessageEditViewModel(Models.Entities.Group group)
        {
            Group = group;
            GroupDelete = new Command(GroupDeleteCommand);
            SaveGroupChange = new Command(UpdateGroup);
            removeUser = new Command((sender) => RemoveGroupUser(sender));
            Task.Run(() => initialize());
        }
        List<UserProfile> _GroupUsers;
        public List<UserProfile> GroupUsers
        {
            get
            {
                return _GroupUsers;
            }
            set
            {
                _GroupUsers = value;
                OnPropertyChanged(nameof(GroupUsers));
            }
        }
        ChatApi request = new ChatApi();
        public async void initialize()
        {
            GroupUsers = await request.GetGroupUsersByGroupId(Group.id) ?? new List<UserProfile>();
        }
        public ICommand removeUser { protected set; get; }
        public ICommand GroupDelete { protected set; get; }
        public ICommand SaveGroupChange { protected set; get; }
        public async void GroupDeleteCommand()
        {
            await request.DeleteGroupByGroupId(Group.id);
            await Application.Current.MainPage.Navigation.PopAsync();
            await PopupNavigation.Instance.PopAsync();
        }

        public async void UpdateGroup()
        {
            await request.UpdateGroup(new GroupUpdate { id = Group.id, name = Group.name, image = new byte[0] });
            await Application.Current.MainPage.Navigation.PopAsync();
            await PopupNavigation.Instance.PopAsync();
        }
        public async void RemoveGroupUser(object sender)
        {
            await request.RemoveUserFromGroup(Group.id, ((UserProfile)sender).userId);
            initialize();
        }
    }
}
