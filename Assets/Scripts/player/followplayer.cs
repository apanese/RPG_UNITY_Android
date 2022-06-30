using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class followplayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float scorllviewspeed;
    public float rotatespeed;
    private Vector3 offset;//摄像机和player的距离
    bool isrotating;
    float movespeed;
    void Start()
    {
        
        scorllviewspeed = 0.1f;
        rotatespeed = 10f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movespeed = player.GetComponent<PlayerMove>().speed;
        this.transform.LookAt(player,this.transform.up);
        offset = this.transform.position- player.position ;
        isrotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)&&!UICamera.isOverUI)
        {
            isrotating = true;
        }
        if (Input.GetMouseButtonUp(0)&&!UICamera.isOverUI)
        {
            isrotating = false;
        }
        if (isrotating)
        {
            //RotateView();
        }
        else
        {
            //follow();
        }
        Vector2 look = TCKInput.GetAxis("test");
        //this.transform.RotateAround(player.transform.position, player.up,1* rotatespeed);
        //follow();
        //scrollview();

    }

    void follow()
    {
        this.transform.position = offset + player.position;
    }
    void scrollview()
    {
        if ((Input.mouseScrollDelta.y != 0 && ((Input.mouseScrollDelta.y * scorllviewspeed + 1) * offset).magnitude > 5 && ((Input.mouseScrollDelta.y * scorllviewspeed + 1) * offset).magnitude < 20)&& !UICamera.isOverUI)
        {
            //Debug.Log(offset);
            offset = (Input.mouseScrollDelta.y * scorllviewspeed + 1) * offset;
            //Debug.Log(Input.mouseScrollDelta);
            //Debug.Log(offset);
            //Debug.Log(offset.magnitude);
            this.transform.position = offset + player.position;
        }
    }
    void RotateView()
    {
        //if(Input.GetAxis("Mouse X")!=0)
        //{
        //    Debug.Log(Input.GetAxis("Mouse X"));
        //};
        if (isrotating)
        {
            this.transform.RotateAround(player.transform.position, player.up, Input.GetAxis("Mouse X") * rotatespeed); //以当帧的player.position为中心进行水平旋转。
            if(player.GetComponent<PlayerMove>().State ==ControlWalkState.Moving) //如果player正在前进，那么摄像机的offset需要加上player.forward.
            {

                //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + Time.deltaTime * movespeed);
            }
            offset = this.transform.position - player.position;
            Debug.Log(this.transform.position);
            Debug.Log(Input.mousePosition);
        }
       

    }
}
