using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHash128 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            Hash128 hs = new Hash128();
            string str = "hello world";
            Log.LogInfo("Hash128 isValid {0} ToString {1}", hs.isValid, hs.ToString());
            hs = new Hash128(1,2,3,4);
            Log.LogInfo("Hash128 isValid {0} ToString {1}", hs.isValid, hs.ToString());
            hs = Hash128.Compute(str);
            Log.LogInfo("Hash128 isValid {0} ToString {1}", hs.isValid, hs.ToString());
            var hashStr = hs.ToString();
            hs = Hash128.Parse(hashStr);
            Log.LogInfo("Hash128 isValid {0} ToString {1}", hs.isValid, hs.ToString());
            hashStr = hashStr.Replace('e', 'f');
            hs = Hash128.Parse(hashStr);
            Log.LogInfo("Hash128 isValid {0} ToString {1}", hs.isValid, hs.ToString());
        }
    }
}
