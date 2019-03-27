using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPing : MonoBehaviour
{
    // Start is called before the first frame update
    public string ip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            StartCoroutine(StartPing());
        }
    }
    IEnumerator StartPing()
    {
        Ping ping = new Ping(ip);
        while (!ping.isDone)
            yield return 100;
        Log.LogInfo("Ping ip {0} isDone {1} time {2}", ping.ip, ping.isDone, ping.time);
        yield return null;
    }
}
