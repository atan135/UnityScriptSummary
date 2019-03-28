using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            //Log.LogInfo("allCameras {0} count {1} current {2} main {3}",
            //    Camera.allCameras.ToString(), Camera.allCamerasCount, Camera.current.name, Camera.main.name);
            Log.LogInfo(Camera.allCameras.ToString());
            Log.LogInfo(Camera.allCamerasCount.ToString());
            Log.LogInfo(Camera.current == null ? "null" : Camera.current.name);
            Log.LogInfo(Camera.main.name);
        }
    }
}
