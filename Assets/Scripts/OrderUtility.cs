using System;
using System.IO;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public static class OrderUtility
{
    public static string GetEatingType()
    {
        var json = File.ReadAllText(Order.OrderPath);
        var order = JsonUtility.FromJson<Order>(json);
        var r = Random.Range(0, order.Content.Count);
        return order.Content[r];
    }

    public static string GetHistoryDesc()
    {
        var stringBuilder = new StringBuilder();
        var json = File.ReadAllText(Order.HistoryPath);
        var history = JsonUtility.FromJson<Order.History>(json);
        foreach(var item in history.items)
        {
            stringBuilder.AppendLine($"{item.date} 点了 {item.content}");
        }
        return stringBuilder.ToString();
    }

    public static void AddEaten(string content)
    {
        if (!File.Exists(Order.HistoryPath))
        {
            File.WriteAllText(Order.HistoryPath, JsonUtility.ToJson(new Order.History()));
        }
        var json = File.ReadAllText(Order.HistoryPath);
        var history = JsonUtility.FromJson<Order.History>(json);
        history.items.Add(new Order.HistoryItem
        {
            content = content,
            date = DateTime.Now.ToString(),
        });
        File.WriteAllText(Order.HistoryPath, JsonUtility.ToJson(history));
    }
}
