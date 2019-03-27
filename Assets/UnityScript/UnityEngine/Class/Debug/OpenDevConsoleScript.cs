using UnityEngine;
using UnityEngine.UI;
public class OpenDevConsoleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Button1").GetComponent<Button>().onClick.AddListener(ClickButton1);
        GameObject.Find("Button2").GetComponent<Button>().onClick.AddListener(ClickButton2);
        GameObject.Find("Button3").GetComponent<Button>().onClick.AddListener(ClickButton3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.developerConsoleVisible = false;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            Debug.developerConsoleVisible = true;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log(Debug.developerConsoleVisible);
            Debug.LogError("ERROR");
        }
    }
    void ClickButton1()
    {
        Log.LogInfo("set developerConsoleVisible false");
        Debug.developerConsoleVisible = false;
        Debug.Log(Debug.developerConsoleVisible);
    }
    void ClickButton2()
    {
        // 修改这个值没有效果，仍然为false
        Log.LogInfo("set developerConsoleVisible true");
        Debug.developerConsoleVisible = true;
        Debug.Log(Debug.developerConsoleVisible.ToString());
    }
    void ClickButton3()
    {
        Log.LogInfo(Debug.developerConsoleVisible.ToString());
        Debug.LogError("ERROR");
    }
}
