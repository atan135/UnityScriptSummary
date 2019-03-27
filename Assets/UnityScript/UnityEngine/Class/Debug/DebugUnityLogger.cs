using UnityEngine;
public class DebugUnityLogger:MonoBehaviour{
    public static ILogger logger = Debug.unityLogger;
    public static string kTag = "My Game Tag";
    void Start()
    {
        MyGameMethod();
    }
    void MyGameMethod()
    {
        logger.Log(kTag, "hello");
        Debug.unityLogger.Log(kTag, "world");
    }
}