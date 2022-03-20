using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using System.Drawing;

namespace MobileHRM.Converter
{
    public class TextLenghConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var targetlen = int.Parse((string)parameter); //targetlengh is lenght you want to change string
            var str = (string)value;
            if(str.Length > targetlen)
                return str.Substring(0, targetlen) + "...";
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
