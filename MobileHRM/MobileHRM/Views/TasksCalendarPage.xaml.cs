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
    public partial class TasksCalendarPage : ContentPage
    {
        public TasksCalendarPage()
        {
            InitializeComponent();
            List<test> f = new List<test>() {
                new test{
                TaskTime = "11:00 AM", task = new List<test2> { new test2 { TaskColor1 = Color.FromHex("26AB5B"), Text1 = "Task" }}},
            new test{
                TaskTime= "12:00 PM", task =new List<test2>{ new test2 { TaskColor1 = Color.FromHex("26AB5B"), Text1 = "Task" }, new test2 { TaskColor1 = Color.FromHex("F07520"), Text1 = "Issue" }, new test2 { TaskColor1 = Color.FromHex("8D8D8D"), Text1 = "Todo" }}},
            new test{ TaskTime="13:00 PM" } ,
             new test{
                TaskTime = "14:00 AM", task = new List<test2> { new test2 { TaskColor1 = Color.FromHex("F07520"), Text1 = "Issue" } }},
             new test{ TaskTime="15:00 PM" } ,
             new test{ TaskTime="16:00 PM" } ,
             new test{ TaskTime="17:00 PM" } ,
             new test{ TaskTime="18:00 PM" } ,
             new test{ TaskTime="19:00 PM" } 
            };
            red.ItemsSource = f;
            red.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 10
            };
        }

        private void OnTabNotification(object sender, EventArgs e)
        {

        }
    }
    public class test
    {
        public string TaskTime { get; set; }
        public List<test2> task { get; set; }

    }
    public class test2
    {
        public Color TaskColor1
        {
            get; set;
        }
        public string Text1 { get; set; }
    }
}

