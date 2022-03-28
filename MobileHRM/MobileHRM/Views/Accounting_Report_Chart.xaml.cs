using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accounting_Report_Chart : ContentPage
    {
        public Accounting_Report_Chart()
        {
            InitializeComponent();
            List<ChartEntry> entries = new List<ChartEntry>()
            {
                new ChartEntry(200)
                {

                    Label = "may",
                    ValueLabel = "2020",
                    Color = SKColor.Parse("#0080ff"),
                },
                new ChartEntry(180)
                {
                    Label = "jun",
                    ValueLabel = "2020",
                    Color = SKColor.Parse("#ff0000")
                },
                 new ChartEntry(150)
                {
                    Label = "april",
                    ValueLabel = "2020",
                    Color = SKColor.Parse("#ffff00")
                },
                new ChartEntry(120)
                {
                    Label = "feb",
                    ValueLabel = "2020",
                    Color = SKColor.Parse("#bfff00")
                },
                               new ChartEntry(100)
                {
                    Label = "mars",
                    ValueLabel = "2020",
                    Color = SKColor.Parse("#ffbf00")
                },
                new ChartEntry(80)
                {
                    Label = "jan",
                    ValueLabel = "2020",
                    Color = SKColor.Parse("#00ff40")
                },
                 new ChartEntry(50)
                {
                    Label = "feb",
                    ValueLabel = "2020",
                    Color = SKColor.Parse("#4d0000")
                },
                  new ChartEntry(40)
                {
                    Label = "april",
                    ValueLabel = "2020",
                    Color = SKColor.Parse("#ffcccc")
                },
                   new ChartEntry(30)
                {
                    Label = "april",
                    ValueLabel = "2020",
                    Color = SKColor.Parse("#00ffff")
                },
                    new ChartEntry(10)
                {
                    Label = "aban",
                    ValueLabel = "56",
                    Color = SKColor.Parse("#bf00ff")

                },
                     new ChartEntry(2)
                {
                    Label = "dey",
                    ValueLabel = "76",
                    Color = SKColor.Parse("#808080")


                }
            };

            List<ChartEntry> entries1 = new List<ChartEntry>()
            {
                 new ChartEntry(60)
                {

                    Label = "",
                    ValueLabel = "",
                    Color = SKColor.Parse("#bfff00")
                },
                      new ChartEntry(2)
                {
                    Label = "",
                    ValueLabel = "",
                    Color = SKColor.Parse("#808080")


                },
                     new ChartEntry(2)
                {
                    Label = "",
                    TextColor = SKColor.Parse("#EBEBEB"),
                    ValueLabel = "",
                    Color = SKColor.Parse("#4d0000")


                }

            };


            charview.Chart = new BarChart { Entries = entries, BackgroundColor = SKColor.Parse("#272B35"), LabelTextSize = 12 };
            charview1.Chart = new PieChart { Entries = entries1, BackgroundColor = SKColor.Parse("#272B35"), LabelTextSize = 12 };
            charview2.Chart = new PieChart { Entries = entries1, BackgroundColor = SKColor.Parse("#272B35"), LabelTextSize = 12 };
        }
    }
}