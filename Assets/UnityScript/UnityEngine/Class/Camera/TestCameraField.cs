using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraField : MonoBehaviour
{
    public Camera cam;
    public int targetDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            Log.LogInfo("Camera renderpath {0} targetTexture {1}", cam.renderingPath, cam.targetTexture);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            Log.LogInfo("Camera targetDisplay {0}", cam.targetDisplay);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            cam.targetDisplay = targetDisplay;
        }
    }
}
