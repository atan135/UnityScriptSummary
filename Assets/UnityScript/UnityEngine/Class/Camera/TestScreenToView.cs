using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScreenToView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Log.LogInfo("position {0}", transform.position);
    }
}
