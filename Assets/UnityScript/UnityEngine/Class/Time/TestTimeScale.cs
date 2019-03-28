using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeScale : MonoBehaviour
{
    public int framerate = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.captureFramerate = framerate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(string.Format("time {0}\tfixedTime {1}\ndeltaTime {2}\tfixedDeltaTime {3}\nunscaledTime {4}\tfixedUnscaledTime {5} framecount {6}",
                                   Time.time, Time.fixedTime,
                                   Time.deltaTime, Time.fixedDeltaTime,
                                   Time.unscaledTime, Time.fixedUnscaledTime, Time.frameCount));
        }
        if(Input.GetKeyDown(KeyCode.A)){
          Log.LogInfo("unscaledTime {0} timesincestartup {1}", Time.unscaledTime, Time.realtimeSinceStartup);
        }
    }
}
