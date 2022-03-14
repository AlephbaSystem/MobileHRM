using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHRM.ViewModel
{
    public class KnowledgeNew : Base
    {
        List<TempModel> _tempModels = new List<TempModel>{
                new TempModel { TagColor="#26AB5B",TagTitle="docker"},
                new TempModel { TagColor="#F07520",TagTitle=".net"},
                new TempModel { TagColor="#7B61FF",TagTitle="ocelot"},
                new TempModel { TagColor="#B33F62",TagTitle="webApi"},
                new TempModel { TagColor="#B36A5E",TagTitle="tutorial"},
                new TempModel { TagColor="#26AB5B",TagTitle="docker"},
                new TempModel { TagColor="#F07520",TagTitle=".net"}
            };

        public List<TempModel> tempModels
        {
            get
            {
                return _tempModels;
            }
            set
            {
                _tempModels = value;
                OnPropertyChanged(nameof(tempModels));
            }
        }
    }

    public class TempModel
    {
        public string TagColor { get; set; }
        public string TagTitle { get; set; }
    }
}
