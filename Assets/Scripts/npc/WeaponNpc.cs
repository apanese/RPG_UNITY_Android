using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNpc : NPC
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log("5555");
        WeaponUI._instance.OnTransformState();
    }
}
