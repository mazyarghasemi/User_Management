using System;
using System.Globalization;


namespace At_First
{
    static class Extensions
    {
        public static string ToRial(this int num)
        {
            return num.ToString("#,0 تومان");
        }
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date) + "/" + pc.GetMonth(date).ToString("00") + "/" + pc.GetDayOfMonth(date).ToString("00");
        }
    }
}
