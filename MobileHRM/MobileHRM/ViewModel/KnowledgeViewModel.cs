using System;
using System.Collections.Generic;
using System.Text;
using MobileHRM.Models.Api;
using MobileHRM.Api;

namespace MobileHRM.ViewModel
{
    public class KnowledgeViewModel : Base
    {
        public KnowledgeViewModel()
        {
        }
        private List<KnowledgeDetail> _items;
        public List<KnowledgeDetail> Items
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
        KnowledgeApi request = new KnowledgeApi();
        public async void initialize()
        {
            Items = await request.GetAllKnowledges(0,20);
        }
    }
}
