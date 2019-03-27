using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTime : MonoBehaviour
{
    public string folder = "ScreenShot";
    public int frameRate = 25;
    // Start is called before the first frame update
    void Start()
    {
        Time.captureFramerate = frameRate;
        System.IO.Directory.CreateDirectory(folder);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            Time.timeScale = 2.0f;
            Time.fixedDeltaTime *= Time.timeScale;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            string name = string.Format("{0}/{1:D04} shot.png", folder, Time.frameCount);
            Log.LogInfo("folder {0} path {1}", folder, name);
            ScreenCapture.CaptureScreenshot(name);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            Log.LogInfo("captureFramerate {0}\ndeltaTime {1}\nfixedDeltaTime {2}\nfixedUnscaledDeltaTime {3}\nfixedUnscaledTime {4}\nframcount {5}\ninFixedTimeStep {6}\nmaximumDeltaTime {7}\nmaximumParticleDeltaTime {8}\nrealtimeSinceStartup {9}\nsmoothDeltaTime {10}\ntime {11} fixedTime {12}\ntimeScale {13}\ntimeSinceLevelLoad{14}\nunscaledDeltaTime {15}\nunscaledTime {16}",
                Time.captureFramerate,
                Time.deltaTime, 
                Time.fixedDeltaTime,
                Time.fixedUnscaledDeltaTime,
                Time.fixedUnscaledTime,
                Time.frameCount,
                Time.inFixedTimeStep,
                Time.maximumDeltaTime,
                Time.maximumParticleDeltaTime,
                Time.realtimeSinceStartup,
                Time.smoothDeltaTime,
                Time.time,
                Time.fixedTime,
                Time.timeScale,
                Time.timeSinceLevelLoad,
                Time.unscaledDeltaTime,
                Time.unscaledTime); 
            Log.LogInfo(Time.time.ToString());
        }
    }
}
