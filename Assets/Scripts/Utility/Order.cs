using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Order
{
    [Serializable]
    public class HistoryItem
    {
        public string date;
        public string content;
    }

    [Serializable]
    public class History
    {
        public List<HistoryItem> items = new List<HistoryItem>();
    }

    public List<string> Content = new List<string>();
    public static string OrderPath
    {
        get
        {
            return Path.Combine(Global.DataFolder, "order.json");
        }
    }
    public static string HistoryPath
    {
        get
        {
            return Path.Combine(Global.DataFolder, "history.txt");
        }
    }
}