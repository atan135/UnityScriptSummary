using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandom : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            for(int i = 0;i < 100; ++i){
                var data = Random.insideUnitCircle;
                Log.LogInfo("random in circle {0}", data);
                Vector3 pos = new Vector3(data.x, data.y, 0);
                GameObject newGo = GameObject.Instantiate(go, pos, new Quaternion(0,0,0,0));
            }
        }
        if(Input.GetKeyDown(KeyCode.S)){
            for(int i = 0;i < 100; ++i){
                var data = Random.insideUnitSphere;
                Log.LogInfo("random in sphere {0}", data);
                GameObject newGo = GameObject.Instantiate(go, data, new Quaternion(0,0,0,0));
            }
        }
        if(Input.GetKeyDown(KeyCode.D)){
            for(int i = 0;i < 100; ++i){
                var data = Random.onUnitSphere;
                Log.LogInfo("random on sphere {0}", data);
                GameObject newGo = GameObject.Instantiate(go, data, new Quaternion(0,0,0,0));
            }
        }
        if(Input.GetKeyDown(KeyCode.F)){
            for(int i = 0;i < 10; ++i){
                Log.LogInfo("random of rotation {0}", Random.rotation);
            }
        }
        if(Input.GetKeyDown(KeyCode.G)){
            Random.InitState(255);
            Log.LogInfo("step 1 random {0}", Random.Range(0.0f, 100.0f));
            Log.LogInfo("step 2 random {0}", Random.Range(0, 100));
            Random.State stat = Random.state;
            Log.LogInfo("step 3 random {0}", Random.Range(0, 100));
            Log.LogInfo("step 4 random {0}", Random.Range(0, 100));
            Random.state = stat;
            Log.LogInfo("step 5 random {0}", Random.Range(0, 100));
            Log.LogInfo("step 6 random {0}", Random.Range(0, 100));
            Random.InitState(255);
            Log.LogInfo("step 7 random {0}", Random.Range(0, 100));
            Log.LogInfo("step 8 random {0}", Random.Range(0, 100));
        }
    }
}
