using UnityEngine;
public class Log{
    public static void LogInfo(string fmt, params object[] objs)
    {
        Debug.Log(string.Format(fmt, objs));
    }
    public static void LogError(string fmt, params object[] objs)
    {
        Debug.LogError(string.Format(fmt, objs));
    }
}