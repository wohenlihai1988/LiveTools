using UnityEngine;

public static class Global
{
    public static string DataFolder
    {
        get
        {
            return Application.streamingAssetsPath;
        }
    }
}
