using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugShopUI : MonoBehaviour
{
    public GameObject Grid;
    public static DrugShopUI _instance;
    public TweenPosition tween;
    public bool ifshow = false;
    Vector3 from_new;
    Vector3 to_new;
    private void Awake()
    {
        
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
        from_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
        to_new = new Vector3(0, 0, 0);
        tween.from = from_new;
        tween.to = to_new;
    }
    // Start is called before the first frame update
    void Start()
    {
       // Grid = this.transform.Find("Grid").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDruhItem(int id)
    {
        Item info = ItemsInfo.GetItemInfoById(id);
        if(info != null)
        {
            GameObject go = GameObject.Instantiate(Resources.Load("WeaponItem"), Grid.transform, false) as GameObject;
            go.GetComponent<WeaponItem>().setid(id);
        }
    }
    public void OnTransformState()
    {
        ifshow = !ifshow;
        if (ifshow)
        {
            this.gameObject.SetActive(true);
            tween.PlayForward();
        }
        else
        {
            tween.PlayReverse();
        }
    }
}
