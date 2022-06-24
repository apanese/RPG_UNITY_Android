using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ApplicationType
{
    Swordman,//剑士
    Magician,//魔术师
    Common //通用
}


public class Item
{
    // Start is called before the first frame update
    public int id;  //id

    public string name;  //名称
    public string icon_name; //icon名称
    //string type_name;
    public string type_name; //类型
    public ObjectType type;
    public int HpGain; //加血量
    public int MpGain; //加魔量
    public int Sell; //出售价
    public int Buy; //购买
    public int count; //数量

    public int attack;
    public int def;
    public ApplicationType applicationType;
    public DressType dressType; //装备的穿着类型
    public int speed;
    public Item()
    {
        
    }
    public Item(int id, string name, string icon_name, string type_name, int hpGain, int mpGain, int sell, int buy)
    {
        this.id = id;  
        this.name = name;
        this.icon_name = icon_name;
        this.type_name = type_name;
        this.HpGain = hpGain;
        this.MpGain = mpGain;
        this.Sell = sell;
        this.Buy = buy;
    }
    public Item(string[] item)
    {
        this.id = int.Parse(item[0]);
        this.name = item[1];
        this.icon_name = item[2];
        this.type_name = item[3];
        this.HpGain = int.Parse(item[4]);
        this.MpGain = int.Parse(item[5]);
        this.Sell = int.Parse(item[6]);
        this.Buy = int.Parse(item[7]);
    }
    public void AddCount()
    {
        count++;
    }
    public void show()
    {
        Debug.Log("id:" +id+ "\nname:" + name + "\nicon_name :" + icon_name + "\ntype_name:" + type_name + "\nHpGain:" + HpGain + "\nMpGain:" + MpGain + "\nSell:" + Sell + "\nBuy:" + Buy + "\nCount:" + count);
    }
    public string GetIconName()
    {
        return this.icon_name;
    }
    public int GetCount()
    {
        return this.count;
    }
}
public enum ObjectType
{
    Drug,
    Equip,
    Mat
}

public enum DressType
{
    Headgear,
    Armor,
    RightHand,
    LeftHand,
    Shoe,
    Accessory

}

public class ItemsInfo : MonoBehaviour
{
    public static ItemsInfo _instance;
    public TextAsset data;
    public static Dictionary<int, Item> iteminfodict = new Dictionary<int, Item>();
    public static Dictionary<int, Item> weaponshopinfodict = new Dictionary<int, Item>();
    public static Dictionary<int, Item> drugshopinfodict = new Dictionary<int, Item>();
    public GameObject drugshop;
    void Awake()
    {
        _instance = this;
    }
    public void Start()
    {
        ReadInfo();
    }
    public static Item GetItemInfoById(int id)
    {
        Item info = null;
        iteminfodict.TryGetValue(id, out info);
        return info;
    }

    void ReadInfo()
    {
        string text = data.text;
        string[] strArray = text.Split("\n");
        foreach(string str in strArray)
        {
            Item info = new Item();
            string[] proArray = str.Split(",");
            int id = int.Parse(proArray[0]);
            string name = proArray[1];
            string icon_name = proArray[2];
            string str_type = proArray[3];
            ObjectType type = ObjectType.Drug;
            switch (str_type) {

                case "Drug":
                    type = ObjectType.Drug;
                    break;

                case "Equip":
                    type = ObjectType.Equip;
                    break;
                case "Mat":
                    type = ObjectType.Mat;
                    break;
            }
            info.id = id;
            info.name = name;
            info.icon_name = icon_name;
            info.type = type;
            if(type == ObjectType.Drug)
            {
                int hp = int.Parse(proArray[4]);
                int mp = int.Parse(proArray[5]);
                int price_sell =int.Parse(proArray[6]);
                int price_buy = int.Parse(proArray[7]);
                info.HpGain = hp;
                info.MpGain = mp;
                info.Sell = price_sell;
                info.Buy = price_buy;
            }
            else if (type == ObjectType.Equip)
            {
                info.attack = int.Parse(proArray[4]);
                info.def = int.Parse(proArray[5]);
                info.speed = int.Parse(proArray[6]);
                info.Sell = int.Parse(proArray[9]);
                info.Buy = int.Parse(proArray[10]);
                string str_dresstype = proArray[7];
                switch (str_dresstype)
                {
                    case "Headgear":
                        info.dressType = DressType.Headgear;
                        break;
                    case "Armor":
                        info.dressType = DressType.Armor;
                        break;
                    case "LeftHand":
                        info.dressType = DressType.LeftHand;
                        break;
                    case "RightHand":
                        info.dressType = DressType.RightHand;
                        break;
                    case "Shoe":
                        info.dressType = DressType.Shoe;
                        break;
                    case "Accessory":
                        info.dressType = DressType.Accessory;
                        break;
                }
                string str_apptype = proArray[8];
                switch (str_apptype)
                {
                    case "Swordman":
                        info.applicationType = ApplicationType.Swordman;
                        break;
                    case "Magician":
                        info.applicationType = ApplicationType.Magician;
                        break;
                    case "Common":
                        info.applicationType = ApplicationType.Common;
                        break;
                }

            }
            iteminfodict.Add(id, info); //添加到字典中，id为key，可以很方便的根据id查找item信息
            //给药品商店插入信息
            //给武器商店插入信息
            if (type == ObjectType.Equip)
            {
                //weaponshopinfodict.Add(id, info);
                WeaponUI._instance.SetWeaponItem(id);
            }
            if (type == ObjectType.Drug)
            {
                DrugShopUI._instance.SetDruhItem(id);
                //drugshop.GetComponent<WeaponUI>().SetWeaponItem(id);
            }



        }
    }

    void weaponshopinit()
    {
        foreach (KeyValuePair<int, Item> kvp in iteminfodict)
        {
            //kvp.Value.icon_name
            //GameObject.Instantiate(Resources.Load("WeaponItem"),)
        }
    }

}
