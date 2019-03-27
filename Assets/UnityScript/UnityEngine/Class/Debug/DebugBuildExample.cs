using UnityEngine;
public class DebugBuildExample : MonoBehaviour{
    void Start()
    {
        Log.LogInfo("Debug isDebugBuild {0}", Debug.isDebugBuild);
    }
}