using MobileHRM.Models;
using MobileHRM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnowledgePage : ContentPage
    {
        public KnowledgeVM Knowledge { get; set; }
        public KnowledgePage()
        {
            InitializeComponent();
            DetailLbl.Text =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Id in lobortis amet enim imperdiet nec cras malesuada et. Morbi feugiat fermentum sit auctor iaculis. Odio sollicitudin leo turpis sit at ut dignissim leo scelerisque. Varius duis proin dignissim in nisl vitae laoreet libero. Dolor fames elit tortor in amet vel. Ultricies in libero mattis et amet urna adipiscing suspendisse. Pulvinar lobortis in scelerisque nunc et." +
                             "Sit at est, cras velit urna sed at.Porttitor volutpat ipsum tellus turpis viverra." +
                             "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Id in lobortis amet enim imperdiet nec cras malesuada et. Morbi feugiat fermentum sit auctor iaculis. Odio sollicitudin leo turpis sit at ut dignissim leo scelerisque. Varius duis proin dignissim in nisl vitae laoreet libero. Dolor fames elit tortor in amet vel. Ultricies in libero mattis et amet urna adipiscing suspendisse. Pulvinar lobortis in scelerisque nunc et." +
                             "Sit at est, cras velit urna sed at.Porttitor volutpat ipsum tellus turpis viverra.";


            Knowledge = new KnowledgeVM();
            Knowledge.Technologies.Add(new Technology() { TechnologyName = "Doker" , TechnologyColor = Color.Yellow});
            Knowledge.Technologies.Add(new Technology() { TechnologyName = "ASP.net" , TechnologyColor = Color.Blue});
            Knowledge.Technologies.Add(new Technology() { TechnologyName = "Php" , TechnologyColor = Color.Red});
            Knowledge.Technologies = Knowledge.Technologies;
            Knowledge.References = Knowledge.References;
            Knowledge = Knowledge;

            Knowledge.References.Add(new Reference()
            {
                RefName = "sdhfklasdklfjha",
                RefLinkShow = "Click Me To Go!",
                RefLink = new Uri("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/bindable-layouts")
            });
            
            Knowledge.References.Add(new Reference()
            {
                RefName = "CLRS Book",
                RefLinkShow = "Go to Binding Docs Microsoft",
                RefLink = new Uri("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/bindable-layouts")
            });

            BindingContext = Knowledge;


            


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            sender = sender;
            Knowledge.Technologies.Add(new Technology() { TechnologyName = "Php123" , TechnologyColor = Color.GreenYellow});
            Knowledge.References.Add(new Reference()
            {
                RefName = "CLRS Book",
                RefLinkShow = "Go to Binding Docs Microsoft",
                RefLink = new Uri("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/bindable-layouts")
            });
            Knowledge.Technologies = Knowledge.Technologies;
            Knowledge = Knowledge;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            sender = sender;
        }
    }
}