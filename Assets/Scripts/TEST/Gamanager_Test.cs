using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Test : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject test2;
    private void Update()
    {
        addgameobject();
    }

    public void addgameobject()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(Resources.Load("Inventory_Item"), test2.transform, false);
        }
    }

}
