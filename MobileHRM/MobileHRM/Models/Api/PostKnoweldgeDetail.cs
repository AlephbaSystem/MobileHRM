using MobileHRM.Models.Entities.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileHRM.Models.Api
{
    public class PostKnoweldgeDetail
    {
        public knowledge knowledge { get; set; }
        public ObservableCollection<reference> references { get; set; } = new ObservableCollection<reference>();
        public ObservableCollection<tag> tags { get; set; } = new ObservableCollection<tag>();
    }
}