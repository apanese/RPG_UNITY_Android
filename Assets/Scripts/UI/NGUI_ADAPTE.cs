using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGUI_ADAPTE : MonoBehaviour
{
    // Start is called before the first frame update
    public float screen_x;
    public float screen_y;
    public float dpi;
    void Start()
    {
        dpi = Screen.dpi;
        screen_x = Screen.width;
        screen_y = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
