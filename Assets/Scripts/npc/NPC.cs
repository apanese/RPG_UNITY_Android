using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseOver()
    {
        Debug.Log("public class NPC : MonoBehaviour");
        CursorManager._instance.settalk();
    }
    void OnMouseExit()
    {
        CursorManager._instance.setnormal();
    }
}
