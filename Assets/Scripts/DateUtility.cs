using System;
using System.Collections.Generic;

public class DateUtility
{
    public static List<DateTime> GetNextGirlDay(DateTime baseDay, int duration)
    {
        var r = new List<DateTime>();
        var next = baseDay;
        while (true)
        {
            next = next.AddDays(duration);
            r.Add(next);
            if (next > DateTime.Now)
            {
                break;
            }
        }
        return r;
    }
}
