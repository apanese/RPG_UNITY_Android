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
        //far 1.��Ұ�����������Ļ������仯 2.��alt+������������ת��Ұ 3.���������ĳ���Ҽ������ƶ�������
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
