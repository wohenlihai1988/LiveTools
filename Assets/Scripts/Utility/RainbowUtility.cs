using System.IO;
using UnityEngine;

public static class RainbowUtility
{
    public static string GirlPefixPath
    {
        get
        {
            return Path.Combine(Global.DataFolder, "prefix.txt");
        }
    }

    public static string GetGrilPrefix()
    {
        var content = File.ReadAllText(GirlPefixPath);
        var array = content.Split('\n');
        var r = Random.Range(0, array.Length);
        while(string.IsNullOrEmpty(array[r]))
        {
            r = Random.Range(0, array.Length);
        }
        return array[r];
    }
}
