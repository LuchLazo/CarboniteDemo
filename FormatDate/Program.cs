using System;

namespace FormatDate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FormatDate(DateTime.Now, "MM-DD-YYYY"));

            Console.WriteLine(FormatDate(DateTime.Now, "DD-MM-YYYY"));
            Console.WriteLine(FormatDate(DateTime.Now, "DD-YYYY-MM"));
            Console.WriteLine(FormatDate(DateTime.Now, "DD-DD-DD"));
            Console.WriteLine(FormatDate(DateTime.Now, "MM-YYYY"));

            Console.WriteLine(FormatDate(DateTime.Now, "MxMMxMMMM"));

        }
        static string FormatDate(DateTime date, string format)
        {
            //return date.ToString(format);
            var month = date.Month.ToString();
            var day = date.Day.ToString();
            var year = date.Year.ToString();

            format = format.Replace("MM", month.PadLeft(2, '0'));
            format = format.Replace("M", month);

            format = format.Replace("DD", day.PadLeft(2, '0'));
            format = format.Replace("D", day);

            format = format.Replace("YYYY", year.PadLeft(4, '0'));
            format = format.Replace("YY", year.Length > 2 ? year.Substring(year.Length - 2) : year.PadLeft(2, '0'));
            format = format.Replace("Y", year);

            return format;
        }
    }
}
