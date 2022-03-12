using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Knowledge : ContentView
    {
        public Knowledge()
        {
            InitializeComponent();
            List<Data> data = new List<Data>() {
               new Data
               {
                Header = "asdasdadas",
                Text = "asdasdasdassdlklksdflhhkjsbfhshkfbsdhdfsd",
                Sub = "read",
                images = new List<Images> {new Images{Image ="vahidzakeri.jpg"},
                new Images{Image ="vahidzakeri.jpg",column=0 },
                    new Images{Image ="vahidzakeri.jpg",column=1},
                    new Images{Image ="vahidzakeri.jpg",column=2 },
                    new Images{Image ="vahidzakeri.jpg",column=3} } },
               new Data
               {
                Header = "asdasdadas",
                Text = "asdasdasdassdlklksdflhhkjsbfhshkfbsdhdfsd",
                Sub = "read",
                images = new List<Images> {new Images{Image ="vahidzakeri.jpg"},
                new Images{Image ="vahidzakeri.jpg",column=0 },
                    new Images{Image ="vahidzakeri.jpg",column=1},
                    new Images{Image ="vahidzakeri.jpg",column=2 },
                    new Images{Image ="vahidzakeri.jpg",column=3} } },
               new Data
               {
                Header = "asdasdadas",
                Text = "asdasdasdassdlklksdflhhkjsbfhshkfbsdhdfsd",
                Sub = "read",
                images = new List<Images> {new Images{Image ="vahidzakeri.jpg"},
                new Images{Image ="vahidzakeri.jpg",column=0 },
                    new Images{Image ="vahidzakeri.jpg",column=1},
                    new Images{Image ="vahidzakeri.jpg",column=2 },
                    new Images{Image ="vahidzakeri.jpg",column=3} } },
               new Data
               {
                Header = "asdasdadas",
                Text = "asdasdasdassdlklksdflhhkjsbfhshkfbsdhdfsd",
                Sub = "read",
                images = new List<Images> {new Images{Image ="vahidzakeri.jpg"},
                new Images{Image ="vahidzakeri.jpg",column=0 },
                    new Images{Image ="vahidzakeri.jpg",column=1},
                    new Images{Image ="vahidzakeri.jpg",column=2 },
                    new Images{Image ="vahidzakeri.jpg",column=3} } },
               new Data
               {
                Header = "asdasdadas",
                Text = "asdasdasdassdlklksdflhhkjsbfhshkfbsdhdfsd",
                Sub = "read",
                images = new List<Images> {new Images{Image ="vahidzakeri.jpg"},
                new Images{Image ="vahidzakeri.jpg",column=0 },
                    new Images{Image ="vahidzakeri.jpg",column=1},
                    new Images{Image ="vahidzakeri.jpg",column=2 },
                    new Images{Image ="vahidzakeri.jpg",column=3} } },
               new Data
               {
                Header = "asdasdadas",
                Text = "asdasdasdassdlklksdflhhkjsbfhshkfbsdhdfsd",
                Sub = "read",
                images = new List<Images> {new Images{Image ="vahidzakeri.jpg"},
                new Images{Image ="vahidzakeri.jpg",column=0 },
                    new Images{Image ="vahidzakeri.jpg",column=1},
                    new Images{Image ="vahidzakeri.jpg",column=2 },
                    new Images{Image ="vahidzakeri.jpg",column=3} } }


            };
            Describtion.ItemsSource = data;
            Describtion.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 10,
            };
        }







    }
    /// <summary>
    /// creat a new model for users information
    /// </summary>
    public class Data
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public string Sub { get; set; }
        public List<Images> images { get; set; }
    }


    /// <summary>
    /// creat a new model for image users
    /// </summary>
    public class Images
    {
        public ImageSource Image { get; set; }
        public int column { get; set; }
    }




}

