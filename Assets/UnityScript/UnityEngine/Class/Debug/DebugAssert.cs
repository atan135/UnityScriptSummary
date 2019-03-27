using UnityEngine;
using UnityEditor;
using System.Reflection;
public class DebugAssert : MonoBehaviour{
    void Start()
    {
        Debug.Assert(1<2);
        Debug.Assert(2<1, "wrong");
        Debug.AssertFormat(2<1, "wrong {0} < {1}", 2, 1);
        GameObject go = GameObject.Find("GameObject");
        Debug.Assert(2<1, "wrong", go);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Break();
            Log.LogInfo("continue");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.ClearDeveloperConsole();
            var assembly = Assembly.GetAssembly(typeof(SceneView));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("go:", gameObject);
            Debug.LogAssertion("wrong");
            Debug.LogAssertion("go wrong", gameObject);
        }
        if(Input.GetKeyDown(KeyCode.F)){
            Debug.LogError("error <b>careful</b>");
            Debug.LogWarning("warning <b>not warry</b>");
            Debug.Log("warning <b>not warry</b>");
        }
    }
}   