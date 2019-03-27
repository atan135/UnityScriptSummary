using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTexture2DRead : MonoBehaviour
{
    bool grab;
    public Renderer m_Display;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            grab = true;
        }
    }
    private void OnPostRender(){
        if(grab){
            Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            texture.Apply();
            if(m_Display != null){
                m_Display.material.mainTexture = texture;
            }
            grab = false;
        }
    }
}
