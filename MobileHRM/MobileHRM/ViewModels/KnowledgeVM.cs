using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MobileHRM.Models;

namespace MobileHRM.ViewModels
{
    public class KnowledgeVM : Base
    {
        public KnowledgeVM()
        {
            References   = new ObservableCollection<Reference>();
            Technologies = new ObservableCollection<Technology>();
        }

        private ObservableCollection<Reference> _References { get; set; }
        public ObservableCollection<Reference> References { 
            get { 
                return _References; 
            } 
            set { 
                _References = value; 
                unPropertyChange(nameof(References));
            } 
        }

        private ObservableCollection<Technology> _Technologies { get; set; }
        public ObservableCollection<Technology> Technologies {
            get
            {
                return _Technologies;
            }
            set
            {
                _Technologies = value; 
                unPropertyChange(nameof(Technologies));
            }
        }

    }
}
