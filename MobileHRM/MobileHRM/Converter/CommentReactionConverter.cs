using MobileHRM.Models.Api;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MobileHRM.Converter
{
    public class CommentReactionConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((Comment)value).reactionId == 0)
            {
                return true;
            }
            if ((string)parameter == "smile")
            {
                return ((Comment)value).isLike;
            }
            else
            {
                return !((Comment)value).isLike;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
