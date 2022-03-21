using System;
using System.Collections.Generic;

public static class DateUtility
{
    public static int DaysFrom(DateTime date)
    {
        var span = DateTime.Now - date;
        return span.Days;
    }

    public static DateTime AddDays(DateTime date, int duration)
    {
        return date.AddDays(duration);
    }

    public static DateTime AddYears(DateTime date, int duration)
    {
        return date.AddYears(duration);
    }

    public static DateTime AddMonths(DateTime date, int duration)
    {
        return date.AddMonths(duration);
    }

    public static string PrettyDayString(DateTime date)
    {
        return date.ToShortDateString();
    }

    public static List<DateTime> GetNextDays(DateTime baseDay, int duration, Func<DateTime, int, DateTime> calculator)
    {
        var r = new List<DateTime>();
        var next = baseDay;
        while (true)
        {
            next = calculator(next, duration);
            r.Add(next);
            if (next > DateTime.Now)
            {
                break;
            }
        }
        return r;
    }

    public static string ToJsonString(this DateTime dateTime)
    {
        return dateTime.ToShortDateString();
    }

    public static DateTime ToDateTime(this string dateTimeString)
    {
        var array = dateTimeString.Split('/');
        return new DateTime(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]));
    }
}
