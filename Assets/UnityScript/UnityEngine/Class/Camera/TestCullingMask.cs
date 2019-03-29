using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCullingMask : MonoBehaviour
{
    public Camera cam;
    float fieldOfView = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        fieldOfView = 60.0f;
        //cam.cullingMask = 1 << 2;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.fieldOfView = fieldOfView;
        if(Input.GetKeyDown(KeyCode.A)){
            Log.LogInfo("mask {0}", cam.cullingMask);
            cam.cullingMask += 1;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            Log.LogInfo("forceIntoRenderTexture {0}", cam.forceIntoRenderTexture);
            cam.forceIntoRenderTexture = true;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            float margin = Random.Range(0.0f, 0.3f);
            cam.rect = new Rect(margin, 0.0f, 1.0f- margin * 2, 1.0f);
        }
    }
/*
    void OnGUI()
    {
        float max, min;
        max = 150.0f;
        min = 20.0f;
        fieldOfView = GUI.HorizontalSlider(new Rect(20, 20, 100, 40), fieldOfView, min, max);
    }
    */
}
