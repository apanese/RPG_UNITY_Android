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
        //cube1 = GameObject.Find("/Cube");  //根据find查找根路径下的Cube对象
        //cube1.SetActive(false);
        //red = GameObject.Find("/Canvas/red");  //根据find查找根路径下/Canvas/red的red对象
        //red.SetActive(false);
        //green = GameObject.Find("/Canvas/green/green1/green"); //根据find查找同一层级下父对象的gameobject
        //green.SetActive(false);
        //GameObject.Find() 总结：从根目录开始寻找GameObject
        //image = green.GetComponentInChildren<Image>();  //GetComponentInChildren从当前层级开始寻找  GetComponent
        //image.color = Color.red;
        //component temp = new component();
        //temp = green.GetComponentInChildren<component>();  //GetComponentInChildren从当前层级开始寻找  GetComponent
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
