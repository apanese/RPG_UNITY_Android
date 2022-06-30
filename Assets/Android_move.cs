using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class Android_move : MonoBehaviour
{
    bool binded;
    Transform mytransform, cameratransform;
    CharacterController characterController;
    float rotation;
    public GameObject player;
    bool jump, preGrounded, isProjectileCube;
    float weapReadyTime;
    bool weapReady;
    Vector3 offset; //camera的移动距离
    Vector3 offset_camera; //camera 旋转时的距离
    //获取脚本属性
    private PlayerAttack attack;
    private PlayerMove mv;
    // Start is called before the first frame update
    void Start()
    {
        mytransform = this.transform;
        cameratransform = Camera.main.transform;
        characterController = GetComponent<CharacterController>();
        TCKInput.SetAxisEnable("Joystick", EAxisType.Vertical, true);
        TCKInput.SetAxisEnable("Joystick", EAxisType.Horizontal, true);
        TCKInput.SetAxisEnable("test", EAxisType.Vertical, true);
        TCKInput.SetAxisEnable("test", EAxisType.Horizontal, true);
        TCKInput.SetSensitivity("Joystick", 5);
        TCKInput.SetSensitivity("test", 1);
        attack = GetComponent<PlayerAttack>();
        mv = GetComponent<PlayerMove>();
        offset = cameratransform.position - mytransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TCKInput.SetAxisEnable("Joystick", EAxisType.Vertical, true);
        TCKInput.SetAxisEnable("Joystick", EAxisType.Horizontal, true);
        TCKInput.SetAxisEnable("test", EAxisType.Vertical, true);
        TCKInput.SetAxisEnable("test", EAxisType.Horizontal, true);
        TCKInput.SetSensitivity("Joystick", 5);
        TCKInput.SetSensitivity("test", 1);
        //offset = cameratransform.position - mytransform.position;
        Vector2 look = TCKInput.GetAxis("test");
        //Debug.Log(look);
        PlayerRotation(look.x, look.y);
        //cameratransform.RotateAround(player.transform.position, mytransform.up, o * 5f);
        //cameratransform.Rotate(Vector3.up, 1 * 5f);
    }

    public void PlayerRotation(float x,float y)
    {
        //mytransform.Rotate(0f, x * 12f, 0f);
        //cameratransform.Rotate(0f, x * 12f, 0f);
        //cameratransform.RotateAround(mytransform.position, mytransform.up, x*5f);
        Vector3 origin_camera = cameratransform.position;
        
        cameratransform.RotateAround(mytransform.position, mytransform.up, x * 5f);
        offset_camera = cameratransform.position - origin_camera;
        cameratransform.RotateAround(mytransform.position, mytransform.right, y * 5f);
        rotation += x * 5f;
        offset = cameratransform.position - mytransform.position;
        //cameratransform.localEulerAngles = new Vector3(-rotation, cameratransform.localEulerAngles.y, 0f);
    }
    void FixedUpdate()
    {
        /*float moveX = TCKInput.GetAxis( "Joystick", EAxisType.Horizontal );
        float moveY = TCKInput.GetAxis( "Joystick", EAxisType.Vertical );*/
        Vector2 move = TCKInput.GetAxis("Joystick"); // NEW func since ver 1.5.5
        Vector3 lookat_ = new Vector3((move.x) * 120f, mytransform.position.y, move.y * 120f);
        lookat_ = Quaternion.AngleAxis(rotation, mytransform.up) * (lookat_ - mytransform.position) + mytransform.position;
        if (move.magnitude!=0)
        {
            float angle = Mathf.Atan2(move.x, move.y);  //angle为半径为1的弧度值
            float tanAngleValue2 = angle / Mathf.PI * 180;//求角度
            //Vector3 lookat_ = new Vector3((move.x + rotation)* 120f, mytransform.position.y, move.y * 120f) - offset_camera;
            //lookat_.x = lookat_.x % 360;
            //lookat_.z = lookat_.z % 360;
            //Debug.Log(lookat_);
            mytransform.LookAt(lookat_);
            //mytransform.LookAt(lookat_);
            attack.state = PlayerState.ControlWalk;
            mv.State = ControlWalkState.Moving;
            characterController.SimpleMove(mytransform.forward*2);
            cameratransform.position = offset + mytransform.position;
        }
        else
        {
            attack.state = PlayerState.ControlWalk;
            mv.State = ControlWalkState.Idle;
        }
    }
    public void PlayerMovement(float x,float y)
    {
       // characterController.Move()
    }
}
