using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MobileHRM.Converter
{
    public class DateConvert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return string.Empty;

            var datetime = (DateTime)value;
            if (datetime.Day == DateTime.Now.Day)
            {
                return datetime.ToLocalTime().ToString("hh:mm");
            }            
            else
            {
                return datetime.ToLocalTime().ToString("dd MMMM yyyy");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}