//Attach this script to your Camera
//This draws a line in the Scene view going through a point 200 pixels from the lower-left corner of the screen
//To see this, enter Play Mode and switch to the Scene tab. Zoom into your Camera's position.
using UnityEngine;
using System.Collections;

public class TestCameraRay : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition) * 5;
        if(Input.GetKeyDown(KeyCode.A)){
            Ray ray = cam.ScreenPointToRay(new Vector3(200, 200, 0));
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            
        }
    }
}