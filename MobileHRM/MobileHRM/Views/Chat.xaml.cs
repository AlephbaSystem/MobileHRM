using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileHRM.ViewModels;

namespace MobileHRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chat3 : ContentPage
    {
        public MessagesVm Vm = new MessagesVm();
        public chat3()
        {
            InitializeComponent();
            BindingContext = Vm;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(msgentry.Text))
            {
                var itm = new Models.MessageItem
                {
                    Text = msgentry.Text,
                    Time = DateTime.Now,
                    To = "1",
                    From = "2",
                    IsMessageYours = sw.IsToggled,
                };

                MakeFrame(itm);
                Vm.MyMessage.Add(itm);
            }
            Vm.MyMessage = Vm.MyMessage;
            msgentry.Text = "";


            
            

        }
        private void MakeFrame(Models.MessageItem Msg)
        {
            Frame frm = new Frame();
            if (Msg.IsMessageYours)
            {
                frm.BackgroundColor = Color.FromHex("#1A1C23");
                frm.Margin=new Thickness(5, 0, 70, 0);
                

                
            }
            else
            {
                frm.Margin=new Thickness(70, 0, 5, 0);
                frm.BackgroundColor = Color.FromHex("#8D8D8D");
            }
            frm.CornerRadius = 20;
            Label lbl = new Label();
            lbl.Text = Msg.Text;
            lbl.TextColor = Color.White;
            lbl.FontSize = 14;
            //lbl.FontFamily = "Quicksand";
            lbl.VerticalTextAlignment = TextAlignment.Center;
            lbl.HorizontalTextAlignment = TextAlignment.Start;
            frm.Content = lbl;
            StacklayoutMsg.Children.Add(frm);
        }
    }
}