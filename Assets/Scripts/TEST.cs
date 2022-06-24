using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TEST : MonoBehaviour
{
    Camera cam;
    bool ifmove;
    GameObject red;
    GameObject green;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        debuglocation();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        red = GameObject.Find("red");
        green = GameObject.Find("green");
    }

    // Update is called once per frame
    void Update()
    {
        testdraw();
    }
    public void printfdebug()
    {
        Debug.Log("it is in debug");
    }
    public void debuglocation()
    {
        Debug.Log(this.transform.position);
    }
    public void debugmouselocation()
    {

        //Vector3 thispos = this.transform.position;
        //Vector3 Screen_thispos = Camera.main.WorldToScreenPoint( this.transform.position);
        if (Input.GetMouseButtonDown(1))
        {
            //Vector3 pos = Input.mousePosition;
            //Vector3 world_mouselocation =  Camera.main.ScreenToWorldPoint(pos);
            //Vector3 temp = new Vector3(Event.current.mousePosition.x, Event.current.mousePosition.y, cam.nearClipPlane);
            //Vector3 temp = new Vector3(0, 0, 1);
            Vector3 world_mouselocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector3 temp_world_mouselocation = Camera.main.ScreenToWorldPoint(temp);
            Debug.Log("Input.mousePosition:" + Input.mousePosition);
            //Debug.Log("Screen_thispos:" + Screen_thispos);
            Debug.Log("Input.mousePosition to worldposition:" + world_mouselocation);
            //Debug.Log("temp_Input.mousePosition:" + temp);
            //Debug.Log("temp_Input.mousePosition to worldposition:" + temp_world_mouselocation);
            //current();
        }
        
    }
    public void current()
    {
       // Debug.Log("Current detected event: " + Event.current.type);
    }
    public void movewithmouse()
    {
        RaycastHit hitinfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //ray.direction = new Vector3(0, 0, 9f);
        bool isColider = Physics.Raycast(ray,out hitinfo);
        if (Input.GetMouseButtonDown(0) )
        {
            Debug.Log("hitinfo:" + hitinfo);
            Debug.Log("isColider:" + isColider);
            Debug.Log("ray:" + ray);
            ifmove = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            ifmove = false;
        }
        if (ifmove && isColider && hitinfo.collider.tag == Tags.player)
        {
            Debug.Log(green.transform.position);
            green.transform.position = Input.mousePosition;
        }
    }
    void testdraw()
    {
        Ray ray = new Ray(this.transform.position, Vector3.forward);
        Debug.DrawRay(this.transform.position, this.transform.position*5, Color.red);
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 temp_mouse = Input.mousePosition;
            Vector3 temp = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawRay(temp, new Vector3(10,10,0), Color.red);
        }
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("play1");
    }


}
