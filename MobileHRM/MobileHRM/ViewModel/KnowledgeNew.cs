using MobileHRM.Api;
using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHRM.ViewModel
{
    public class KnowledgeNew : Base
    {
        public KnowledgeNew()
        {
            OnSave = new Command(OnSaveClicked);
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
        }
    }
}
