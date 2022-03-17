using MobileHRM.Api;
using MobileHRM.Models;
using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHRM.ViewModel
{
    public class KnowledgeNewViewModel : Base
    {
        public KnowledgeNewViewModel()
        {
            OnSave = new Command((sender) => OnSaveClicked(sender));
            KnowledgeDetail = new PostKnoweldgeDetail { knowledge = new Models.Entities.Request.knowledge(), references = new ObservableCollection<Models.Entities.Request.reference>(), tags = new ObservableCollection<Models.Entities.Request.tag>() };
            KnowledgeDetail.knowledge.userId = User.UserId;
        }
        private bool _Tagcheck { get; set; }
        public bool Tagcheck
        {
            get { return _Tagcheck; }
            set
            {
                _Tagcheck = value;
                OnPropertyChanged(nameof(Tagcheck));
            }
        }
        private bool _ReferenceCheck { get; set; }
        public bool ReferenceCheck
        {
            get { return _ReferenceCheck; }
            set
            {
                _ReferenceCheck = value;
                OnPropertyChanged(nameof(ReferenceCheck));
            }
        }
        public bool SaveEnabled
        {
            get { return _SaveEnabled; }
            set
            {
                _SaveEnabled = value;
                OnPropertyChanged(nameof(SaveEnabled));
            }
        }
        private bool _SaveEnabled { get; set; }
        private PostKnoweldgeDetail _KnowledgeDetail;
        public PostKnoweldgeDetail KnowledgeDetail
        {
            get
            {
                return _KnowledgeDetail;
            }
            set
            {
                _KnowledgeDetail = value;
                Tagcheck = !Convert.ToBoolean(KnowledgeDetail.tags.Count);
                ReferenceCheck = !Convert.ToBoolean(KnowledgeDetail.references.Count);
                SaveEnabled = !(Tagcheck || ReferenceCheck);
                OnPropertyChanged(nameof(KnowledgeDetail));
            }
        }

        KnowledgeApi request = new KnowledgeApi();
        public ICommand OnSave { get; protected set; }
        private async void OnSaveClicked(object sender)
        {
            if (KnowledgeDetail.tags == null || KnowledgeDetail.references == null)
            {
                return;
            }
            bool res = await request.PostKnowledge(KnowledgeDetail);
            if (res)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
