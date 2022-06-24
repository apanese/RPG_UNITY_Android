using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory _instance;
    public TextAsset text;
    public static GameObject inventorydes;
    private List<Item> items = new List<Item> ();
    private string[]  items_temp; //存储所有行的数据
    private string[] item_temp; //存储单行的数据
    public GameObject[] item_grids; //scene里所有的item_grids;
    public List<Item_Grid> itemGridList;
    public List<Item> GainItems = new List<Item>(); //存储已获得的items
    private TweenPosition Inventory_Tween;  //
    public GameObject Inventory_Item_Prefab;

    public UILabel coin_num; //记录金币的个数
    void Awake()
    {
        _instance = this;
        Debug.Log("Inventory Awake");
        itemGridList = new List<Item_Grid>(this.GetComponentsInChildren<Item_Grid>());
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Inventory_Tween = this.GetComponent<TweenPosition>();
        inventorydes = GameObject.Find("InventoryDes");
        inventorydes.SetActive(false);
        Debug.Log("Inventory start");
        //readdata();
        //updatebagdata();

        
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateGainItems();
        //updatebagdata();
    }
    public void CloseBtn_Click() //bag页面的关闭按钮
    {
        this.gameObject.SetActive(false);
        ShowItems();
    }
    void ShowItems()  //调bug时用，显示items下所有item
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].show();
        }
    }
    void updatebagdata()  //更新显示bag里的道具信息
    {
        for(int i=0;i<GainItems.Count;i++)
        {
            UISprite temp_UIsprite = item_grids[i].transform.Find("icon").GetComponent<UISprite>();
            UILabel temp_UIlabel = item_grids[i].transform.Find("Label").GetComponent<UILabel>();
            setsprite(temp_UIsprite, GainItems[i]);
            setLabel(temp_UIlabel, GainItems[i]);
        }
        for(int i = GainItems.Count;i<20;i++)
        {
            UISprite temp_UIsprite = item_grids[i].transform.Find("icon").GetComponent<UISprite>();
            UILabel temp_UIlabel = item_grids[i].transform.Find("Label").GetComponent<UILabel>();
            item_grid_init(temp_UIsprite, temp_UIlabel);
        }
        if (item_grids.Length == 0)
        {
            this.GetComponentInChildren<UISprite>();
        }
    }
    void setsprite(UISprite item_grid,Item item) //item_grid直接对应icon
    {
        //origin.transform.gameObject.activeInHierarchy orgin所在对象的激活状态。
        if(!item_grid.transform.gameObject.activeInHierarchy) //还没激活
        {
            item_grid.transform.gameObject.SetActive(true);
        }
        //UISprite child = item_grid.GetComponent<UISprite>();
        item_grid.spriteName = item.GetIconName();
    }
    void setLabel(UILabel origin, Item item)
    {
        Debug.Log(item.GetCount());
        if (item.GetCount() > 1)
        {
            origin.text = item.GetCount().ToString();
            origin.transform.gameObject.SetActive(true);
        }
        else
        {
            origin.transform.gameObject.SetActive(false);
        }
    }
    void item_grid_init(UISprite a,UILabel b)  //icon和label均初始化为0
    {
        a.transform.gameObject.SetActive(false);
        b.transform.gameObject.SetActive(false);
    }
    public void ShowInventory()
    {
        //this.gameObject.SetActive(true);
        Inventory_Tween.PlayForward();
    }
    public void HideInventory()
    {
        Inventory_Tween.PlayReverse();
    }

    //拾取到id的物品，并添加到物品栏里面
    public void GetId(int id,int count = 1)
    {
        Item_Grid grid = null;
        foreach(Item_Grid temp in itemGridList)
        {
            if(temp.id == id)
            {
                grid = temp;
                break;
            }
        }
        if(grid != null)
        {
            grid.PlusNumber(count);
        }
        else
        {
            foreach (Item_Grid temp in itemGridList)
            {
                if (temp.id == 0)
                {
                    grid = temp;
                    break;
                }
            }
            if (grid != null)
            {
                //GameObject itemGo = NGUITools.AddChild(grid.gameObject, Inventory_Item_Prefab);
                //itemGo.transform.localPosition = Vector3.zero;
                //itemGo.GetComponent<UISprite>().depth = 15;
                grid.SetId(id, count);           
            }
        }
    }
    //public bool BuySuccess(int id,int num =1)
    //{
    //    Item info = ItemsInfo.GetItemInfoById(id);

    //    if(co)

    //}
    public void updateCoin(int coin)
    {
        coin_num.text = coin.ToString();
    }
}
