using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Item : UIDragDropItem
{
    // Start is called before the first frame update
    private UISprite sprite;
    private Vector3 origin;
    public GameObject inventorydes;
    private Item_Grid item_grid;
    private int id;
    bool ifhover;
    
    void Awake()
    {
        base.Awake();
        sprite = this.GetComponent<UISprite>();
        item_grid = this.transform.parent.GetComponent<Item_Grid>();
    }
    private void Start()
    {
        inventorydes = Inventory.inventorydes;
        
    }
    void Update()
    {
        base.Update();
        if (ifhover)
        {
            inventorydes.GetComponentInChildren<InventoryDes>().show(item_grid.id);
            if (Input.GetMouseButtonDown(1))
            {
                bool success = EquipmentUI._instance.Dress(item_grid.id);
                if (success)
                {
                    transform.parent.GetComponent<Item_Grid>().MinusNumber();
                }

                
            }
        }
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        //tag为InventoryItem，证明格子有东西，两格子交换。
        //tag为InventoryItemGrid，证明格子没东西，格子移过去。
        //tag为其他，格子不变。
        //this.transform.parent.GetComponent<Item_Grid>().Clear();
        if (surface != null)
        {
            if (surface.tag == Tags.InventoryGrid) //值类型和引用类型的区别,移过去的格子为空格子
            {
                if(surface == this.transform.gameObject) //移到原本的格子里
                {
                    this.transform.localPosition = Vector3.zero; //回归原位
                }
                else
                {
                    Item_Grid oldparent = this.transform.parent.gameObject.GetComponent<Item_Grid>();
                    surface.GetComponent<Item_Grid>().SetId(oldparent.id, oldparent.num);
                    oldparent.Clear();
                }
                
                //this.transform.localPosition = Vector3.zero;
                //this.transform.GetComponentInChildren<Inventory_Item>().gameObject.GetComponent<>
                //surface.GetComponentInChildren<UISprite>().spriteName = "";
                //surface.GetComponent<UISprite>().spriteName = "icon-potion2"; //如果移过去的是空格，则赋上中等药水图片。
            }
            else if (surface.tag == Tags.InventoryItem)
            {
                Item_Grid newparent = surface.transform.parent.gameObject.GetComponent<Item_Grid>();
                Item_Grid oldparent = this.transform.parent.gameObject.GetComponent<Item_Grid>();
                int tempid = newparent.id;
                int tempnum = newparent.num;
                newparent.SetId(oldparent.id, oldparent.num);
                oldparent.SetId(tempid, tempnum);
                //oldparent.transform.localPosition = Vector3.zero;
                this.transform.localPosition = Vector3.zero;
            }
            else
            {
                this.transform.localPosition = Vector3.zero;
            }

        }
        
    }
    public void onHoverover()
    {
        ifhover = true;
    }
    public void onHoverexit()
    {
        ifhover = false;

    }

}
