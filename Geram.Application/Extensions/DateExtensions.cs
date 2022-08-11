using System.Globalization;

namespace Geram.Application.Extensions
{
    public static class DateExtensions
    {
        public static string ToShamsi(this DateTime date)
        {
            var persianCalendar = new PersianCalendar();

            return
                $"{persianCalendar.GetYear(date)}/{persianCalendar.GetMonth(date).ToString("00")}/{persianCalendar.GetDayOfMonth(date).ToString("00")}";
        }

        public static DateTime ToMiladi(this string date)
        {
            var splitedDate = date.Split("/");

            var year = Convert.ToInt32(splitedDate[0]);
            var month = Convert.ToInt32(splitedDate[1]);
            var day = Convert.ToInt32(splitedDate[2]);

            return new DateTime(year, month, day, new PersianCalendar());
        }
    }
}
