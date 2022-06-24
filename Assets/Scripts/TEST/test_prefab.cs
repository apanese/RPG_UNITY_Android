using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_prefab : MonoBehaviour
{
    // Start is called before the first frame update
    bool ifhover;
    public GameObject label;
    void Update()
    {
        
        //if(ifhover)
        //{
        //    GameObject.Find("Label").SetActive(true);
        //}
    }

    public void onhoveron()
    {
        
        ifhover = true;
        label.SetActive(true);
        Debug.Log(this.transform.name + "    " + ifhover);
    }
    public void onhoverexit()
    {
        ifhover = false;
        label.SetActive(false);
        Debug.Log(this.transform.name + "    " + ifhover);
    }

}
