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
        //tagΪInventoryItem��֤�������ж����������ӽ�����
        //tagΪInventoryItemGrid��֤������û�����������ƹ�ȥ��
        //tagΪ���������Ӳ��䡣
        //this.transform.parent.GetComponent<Item_Grid>().Clear();
        if (surface != null)
        {
            if (surface.tag == Tags.InventoryGrid) //ֵ���ͺ��������͵�����,�ƹ�ȥ�ĸ���Ϊ�ո���
            {
                if(surface == this.transform.gameObject) //�Ƶ�ԭ���ĸ�����
                {
                    this.transform.localPosition = Vector3.zero; //�ع�ԭλ
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
                //surface.GetComponent<UISprite>().spriteName = "icon-potion2"; //����ƹ�ȥ���ǿո������е�ҩˮͼƬ��
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
