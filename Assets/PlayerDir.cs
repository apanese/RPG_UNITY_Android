using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDir : MonoBehaviour
{
    public GameObject effect_click_prefab;
    private bool isMoving = false;//��ʾ����Ƿ���
    public Vector3 targetPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        effect_click_prefab.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)&&!UICamera.isOverUI) //UICamera.hoveredObject ��˼����������Ƿ���UI�ؼ������û�з���null
        {
            Debug.Log("GetMouseButtonDown(1)");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            bool isColider = Physics.Raycast(ray, out hitinfo);
            if(isColider&&hitinfo.collider.tag == Tags.ground)
            {
                isMoving = true;
                //ʵ�������������Ч��
                ShowClickEffect(hitinfo.point);
                LookAtTarget(hitinfo.point);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            isMoving = false;
            Debug.Log("Input.GetMouseButtonUp(1)");
        }
    }

    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3((float)hitPoint.x, (float)hitPoint.y+0.1f, (float)hitPoint.z);
        GameObject.Instantiate(effect_click_prefab,hitPoint,Quaternion.identity);
    }
    //�����ǳ���Ŀ��λ��
    void LookAtTarget(Vector3 hitpoint)
    {
        targetPosition = hitpoint;
        targetPosition = new Vector3(hitpoint.x, (float)transform.position.y, (float)hitpoint.z); 
        this.transform.LookAt(targetPosition);
    }

}
