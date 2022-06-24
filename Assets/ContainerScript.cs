using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNewGame()
    {
        PlayerPrefs.SetInt("DataFromSave", 0);
    }
    public void OnLoadGamme()
    {
        PlayerPrefs.SetInt("DataFromSave", 1);
    }
    
}
