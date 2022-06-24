using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    bool ifrun = true;
     void Awake()
    {
        Debug.Log(this.gameObject.name + "Awake");
    }
    void Start()
    {
        Debug.Log(this.gameObject.name + "Start");
    }

    // Update is called once per frame
    void Update()
    {
        if(ifrun)
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log(this.gameObject.name + " upsdate:"+i);
            }
            ifrun = false;
        }
        
    }
}
