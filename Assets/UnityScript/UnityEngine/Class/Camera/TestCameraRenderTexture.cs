using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCameraRenderTexture : MonoBehaviour
{
    public Renderer mainCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            var cam = GetComponent<Camera>();
            Log.LogInfo("activeTexture {0} renderpath {1}", cam.activeTexture.name, cam.renderingPath);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
            GetComponent<Camera>().targetTexture = rt;
            mainCube.material.mainTexture = rt;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (gameObject.name == "Camera")
            {
                RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
                rt.name = "camera rt";
                var go = GameObject.Find("Canvas/Image");
                GetComponent<Camera>().targetTexture = rt;
                Material mt = new Material(Shader.Find("UI/Default"));
                mt.mainTexture = rt;
                go.GetComponent<Image>().material = mt;
            }
            else
            {
                RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
                rt.name = "camera1 rt";
                var go = GameObject.Find("Canvas/RawImage");
                GetComponent<Camera>().targetTexture = rt;
                go.GetComponent<RawImage>().texture = rt;
            }

        }

    }
}
