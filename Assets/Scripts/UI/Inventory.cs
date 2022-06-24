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
    private string[]  items_temp; //�洢�����е�����
    private string[] item_temp; //�洢���е�����
    public GameObject[] item_grids; //scene�����е�item_grids;
    public List<Item_Grid> itemGridList;
    public List<Item> GainItems = new List<Item>(); //�洢�ѻ�õ�items
    private TweenPosition Inventory_Tween;  //
    public GameObject Inventory_Item_Prefab;

    public UILabel coin_num; //��¼��ҵĸ���
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
    public void CloseBtn_Click() //bagҳ��Ĺرհ�ť
    {
        this.gameObject.SetActive(false);
        ShowItems();
    }
    void ShowItems()  //��bugʱ�ã���ʾitems������item
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].show();
        }
    }
    void updatebagdata()  //������ʾbag��ĵ�����Ϣ
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
    void setsprite(UISprite item_grid,Item item) //item_gridֱ�Ӷ�Ӧicon
    {
        //origin.transform.gameObject.activeInHierarchy orgin���ڶ���ļ���״̬��
        if(!item_grid.transform.gameObject.activeInHierarchy) //��û����
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
    void item_grid_init(UISprite a,UILabel b)  //icon��label����ʼ��Ϊ0
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

    //ʰȡ��id����Ʒ������ӵ���Ʒ������
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
