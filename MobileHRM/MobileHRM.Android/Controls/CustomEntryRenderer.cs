using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MobileHRM.Controls;
using MobileHRM.Droid.Controls;
using System;


#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace MobileHRM.Droid.Controls
{
    [Obsolete]
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.Transparent);
                Control.SetBackgroundDrawable(gd);
                Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(Android.Graphics.Color.LightGray));
            }
        }
    }
}