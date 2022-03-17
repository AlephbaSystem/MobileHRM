using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MobileHRM.Helper
{
    public static class PersianDateTimeConverter
    {
        public static DateTime DateTimeToPersian(DateTime date)
        {
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date), calendar.GetHour(date), calendar.GetMinute(date), calendar.GetSecond(date));
            return persianDate;
        }
    }
}
