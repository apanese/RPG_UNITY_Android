using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraState
{
    far,
    near
}
public class cameramove : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera main;
    public Camera camera2;
    public GameObject player;
    public CameraState cs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //far 1.视野距离随着鼠标的滑动而变化 2.按alt+鼠标左键可以旋转视野 3.鼠标点击地形某处右键可以移动到那里
        //near 2.
        if (Input.GetMouseButtonDown(0))
        {
            if (cs == CameraState.far)
            {

                bool ifcolider;
                Ray ray;
                RaycastHit hitinfo;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                ifcolider = Physics.Raycast(ray, out hitinfo);
                if (hitinfo.collider.tag == Tags.ground)
                {
                    //
                }
                else
                {

                }
            }
            else
            {

            }
        }
        

    }
    void change(CameraState cs)
    {
        this.cs = cs;
    }

}
