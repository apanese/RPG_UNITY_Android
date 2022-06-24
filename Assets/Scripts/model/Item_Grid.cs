using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Grid : MonoBehaviour
{
    public int id;
    public int num;
    public string logo_name;
    private GameObject Inventory_Item;
    public Inventory_Item inventory_item_c;
    private UILabel Num_Label;
    private Item item;
    private void Awake()
    {
        Num_Label = this.transform.GetComponentInChildren<UILabel>();
    }
    //public GameObject Inventory = ;
    public void Clear()
    {
        Inventory_Item = this.transform.GetComponentInChildren<Inventory_Item>().gameObject;
        num = 0;
        id = 0;
        Num_Label.enabled = false;
        Destroy(Inventory_Item);
    }
    public void SetId(int id,int num) //��ʼ��һ��grid
    {
        //1.itemΪ��
        //2.item��Ϊ��
        item = ItemsInfo.GetItemInfoById(id); //��ȡitem��Ϣ
        //Inventory_Item = this.transform.GetComponentInChildren<Inventory_Item>().gameObject; //
        //inventory_item = this.transform.GetComponentInChildren<Inventory_Item>(true);
        if (Inventory_Item == null) //��һ�����
        {
            Inventory_Item = (GameObject)Instantiate(Resources.Load("Inventory_Item"), this.transform, false);
        }
        this.id = id;
        this.num = num;
        Inventory_Item.GetComponent<UISprite>().spriteName = item.icon_name;
        Num_Label.text = this.num.ToString();
        Num_Label.enabled = true;
    }

    public void PlusNumber(int num = 1)
    {
        this.num+= num;
        Num_Label.text = this.num.ToString();
    }

    public bool MinusNumber(int num = 1)
    {
        if(this.num >= num)
        {
            this.num-=num;
            Num_Label.text = this.num.ToString();
            if(this.num == 0)
            {
                Clear(); //��մ洢����Ϣ
                GameObject.Destroy(this.GetComponentInChildren<Inventory_Item>().gameObject);
            }
            return true;
        }
        return false;
    }



    


    
}
