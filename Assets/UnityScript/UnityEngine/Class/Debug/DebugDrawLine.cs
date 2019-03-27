using UnityEngine;
public class DebugDrawLine : MonoBehaviour{
    // 编辑器下不能生效
    void Start()
    {
        Debug.DrawLine(Vector3.zero, new Vector3(5,0,0), Color.red, 1000f);
    }
    private float q = 0.0f;

    void FixedUpdate()
    {
        // always draw a 5-unit colored line from the origin
        Color color = new Color(q, q, 1.0f);
        Debug.DrawLine(Vector3.zero, new Vector3(0, 5, 0), color, 1000f);
        q = q + 0.01f;

        if (q > 1.0f)
        {
            q = 0.0f;
        }
    }
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green, 1000f);
    }
}