using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class EditorUtility
{
    [MenuItem("Init/GenerateOrder")]
    public static void GenerateOrder()
    {
        var srcfile = File.ReadAllText("f:/eat.txt");
        srcfile = srcfile.Replace("\r", "");
        var array = srcfile.Split('\n');
        var list = new List<string>();
        for(var i = 0; i < array.Length; i++)
        {
            list.Add(array[i]);
        }
        var order = new Order
        {
            Content =  list,
        };
        var json = JsonUtility.ToJson(order);
        File.WriteAllText(Order.OrderPath, json);
        AssetDatabase.Refresh();
    }

    [MenuItem("Init/GeneratePrefix")]
    public static void GeneratePrefix()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("可爱");
        stringBuilder.AppendLine("美丽");
        stringBuilder.AppendLine("超级大长腿");
        stringBuilder.AppendLine("笨笨");
        stringBuilder.AppendLine("乖乖");
        stringBuilder.AppendLine("秀外慧中");
        stringBuilder.AppendLine("从不迷路");
        stringBuilder.AppendLine("闭月羞花");
        stringBuilder.AppendLine("沉鱼落雁");
        File.WriteAllText(RainbowUtility.GirlPefixPath, stringBuilder.ToString());
        AssetDatabase.Refresh();
    }
}
