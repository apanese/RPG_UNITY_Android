using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class component : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject green;
    private Transform green_transform;
    private GameObject green1;
    private GameObject green2;
    private GameObject red;
    private GameObject red1;
    private GameObject red2;
    private GameObject cube1;
    //private Sprite image;
    private Image image;
    private List<Image> images;
    void Start()
    {
        image = this.transform.GetComponentInChildren<Image>();
        image.color = Color.black;
        //green.SetActive(false);
        //cube1 = GameObject.Find("/Cube");  //����find���Ҹ�·���µ�Cube����
        //cube1.SetActive(false);
        //red = GameObject.Find("/Canvas/red");  //����find���Ҹ�·����/Canvas/red��red����
        //red.SetActive(false);
        //green = GameObject.Find("/Canvas/green/green1/green"); //����find����ͬһ�㼶�¸������gameobject
        //green.SetActive(false);
        //GameObject.Find() �ܽ᣺�Ӹ�Ŀ¼��ʼѰ��GameObject
        //image = green.GetComponentInChildren<Image>();  //GetComponentInChildren�ӵ�ǰ�㼶��ʼѰ��  GetComponent
        //image.color = Color.red;
        //component temp = new component();
        //temp = green.GetComponentInChildren<component>();  //GetComponentInChildren�ӵ�ǰ�㼶��ʼѰ��  GetComponent
        //temp.show();

    }
    void show()
    {
        Debug.Log("show");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
