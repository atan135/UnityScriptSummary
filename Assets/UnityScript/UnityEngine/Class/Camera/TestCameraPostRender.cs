using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraPostRender : MonoBehaviour
{
    void MyPostRender(Camera camera){
        Log.LogInfo("PostRender {0} from camera {1}", gameObject.name, camera.name);
    }
    public void OnEnable(){
        Camera.onPostRender += MyPostRender;
    }
    public void OnDisable(){
        Camera.onPostRender -= MyPostRender;
    }
}
