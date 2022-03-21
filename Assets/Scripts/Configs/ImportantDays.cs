using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImportantDay
{
    public string Title;
    public string DateTime;
}

public class ImportantDays
{
    private static string SavePath
    {
        get
        {
            if (string.IsNullOrEmpty(m_savePath))
            {
                m_savePath = Path.Combine(Global.DataFolder, FileName);
            }
            return m_savePath;
        }
    }
    private const string FileName = "important_days.json";
    private static string m_savePath;

    public List<ImportantDay> Days = new List<ImportantDay>();
    private Dictionary<string, ImportantDay> m_dayMap = new Dictionary<string, ImportantDay>();
    public void Save()
    {
        var json = JsonUtility.ToJson(this);
        File.WriteAllText(SavePath, json);
    }

    public static ImportantDays Load()
    {
        var json = File.ReadAllText(SavePath);
        var config = JsonUtility.FromJson<ImportantDays>(json);
        return config;
    }

    public string GetDayDesc(string key)
    {
        if(!m_dayMap.TryGetValue(key, out var day))
        {
            return "";
        }
        var date = day.DateTime.ToDateTime();
        var nextYear = DateUtility.GetNextDays(date, 1, DateUtility.AddMonths);
        var nextMonth = DateUtility.GetNextDays(date, 1, DateUtility.AddYears);
        var nextHundred = DateUtility.GetNextDays(date, 100, DateUtility.AddDays);
        return $"{key}为{DateUtility.PrettyDayString(date)},至今已经{DateUtility.DaysFrom(date)}天\n距离下个一个一百天还有{nextHundred}天\n距离下一个月纪念日还有{nextMonth}天\n距离下一个年纪念日还有{nextYear}天";
    }
}
