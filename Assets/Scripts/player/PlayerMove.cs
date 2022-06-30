using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlWalkState { 
    Moving,
    Idle
};

public class PlayerMove : MonoBehaviour
{
    public float speed = 1;
    private PlayerDir dir;
    private CharacterController controller;
    public ControlWalkState State;
    private PlayerAttack attack;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        dir = this.GetComponent<PlayerDir>();  
        controller = this.GetComponent<CharacterController>();
        attack = this.GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if(attack.state == PlayerState.ControlWalk)
        //{
        //    float distance = Vector3.Distance(dir.targetPosition, transform.position);
        //    //Debug.Log("dir.targetPosition"+dir.targetPosition);
        //    //Debug.Log("transform.position"+transform.position);
        //    if (distance <= 0.5f)
        //    {
        //        isMoving = false;
        //        State = ControlWalkState.Idle;
        //    }
        //    else
        //    {
        //        isMoving=true;
        //        State = ControlWalkState.Moving;
        //        controller.SimpleMove(transform.forward * speed);
        //    }
        //}
    }

    public void SimpleMove(Vector3 targetPos)
    {
        transform.LookAt(targetPos);
        controller.SimpleMove(transform.forward*speed);
    }
}
