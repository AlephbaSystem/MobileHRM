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
            OnSave = new Command(OnSaveClicked);
            KnowledgeDetail = new PostKnoweldgeDetail {knowledge=new Models.Entities.Request.knowledge(),references=new ObservableCollection<Models.Entities.Request.reference>(),tags=new ObservableCollection<Models.Entities.Request.tag>() };
            KnowledgeDetail.knowledge.userId = User.UserId;
        }
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
