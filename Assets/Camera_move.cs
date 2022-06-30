using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class Camera_move : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(player.transform.position, player.transform.up, 1);
    }
}
