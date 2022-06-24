using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDes : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryDes _instance;
    public UILabel label;

    public float timer = 3;
    private void Awake()
    {
        Debug.Log("Awake");
        _instance = this;
        label = this.GetComponentInChildren<UILabel>();
    }
    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeInHierarchy == true)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                this.gameObject.SetActive(false);
                
            }
        }
    }
    public void show(int id)
    {
        this.gameObject.SetActive(true);
        timer = 0.4f;
        transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
        Item item = ItemsInfo.GetItemInfoById(id);
        if (item != null)
        {
            switch (item.type)
            {
                case ObjectType.Drug:
                    label.text = "名称：" + item.name + "\n" + "+HP:" + item.HpGain + "\n" + "+MP:" + item.MpGain + "\n" + "sell:" + item.Sell + "\n" + "buy:" + item.Buy;
                    break;
                case ObjectType.Equip:
                    label.text = "名称：" + item.name + "\n" + "+攻击力:" + item.attack + "\n" + "+防御力:" + item.def + "\n" + "+速度:" + item.speed + "\n" + "sell:" + item.Sell + "\n" + "buy:" + item.Buy;
                    break;

            }
        }
        this.gameObject.SetActive(true);
    }
}
