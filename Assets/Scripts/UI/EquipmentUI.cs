using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public static EquipmentUI _instance;
    private TweenPosition tween;
    private bool isShow = false;

    private GameObject headgear;
    private GameObject armor;
    private GameObject rightHand;
    private GameObject leftHand;
    private GameObject shoe;
    private GameObject accessory;

    private PlayerStatus ps;

    public GameObject equipmentItem;

    public int attack = 0;
    public int def = 0;
    public int speed = 0;

    private void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();

        headgear = transform.Find("Headgear").gameObject;
        armor = transform.Find("Armor").gameObject;
        rightHand = transform.Find("Right_Hand").gameObject;
        leftHand = transform.Find("Left_Hand").gameObject;
        shoe = transform.Find("Shoe").gameObject;
        accessory = transform.Find("Accessory").gameObject;

        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();

    }
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransformState()
    {
        if(isShow == false)
        {
            tween.PlayForward();
            isShow = true;
        }
        else
        {
            tween.PlayReverse();
            isShow = false;
        }
    }

    public bool Dress(int id)
    {
        //item
        Item info = ItemsInfo.GetItemInfoById(id);
        if (info.type != ObjectType.Equip)
        {
            return false;
        }
        if(ps.heroType == HeroType.Magician)
        {
            if(info.applicationType != ApplicationType.Magician&&info.applicationType!=ApplicationType.Common)
            {
                return false;
            }
        }
        if(ps.heroType == HeroType.Swordman )
        {
            if(info.applicationType != ApplicationType.Swordman && info.applicationType != ApplicationType.Common)
            {
                return false;
            }
        }
        GameObject parent = null;
        switch (info.dressType)
        {
            case DressType.Headgear:
                parent = headgear;
                break;
            case DressType.Armor:
                parent = armor;
                break;
            case DressType.RightHand:
                parent = rightHand;
                break;
            case DressType.LeftHand:
                parent = leftHand ;
                break;
            case DressType.Shoe:
                parent = shoe;
                break;
            case DressType.Accessory:
                parent = accessory;
                break;
        }
        EquipmentItem item = parent.GetComponentInChildren<EquipmentItem>();
        if (item != null) //说明已经穿戴了同样类型的装备
        {
            Inventory._instance.GetId(item.id, 1); //把原有装备卸下
            item.SetInfo(info);
        }
        else //没有穿戴同样类型的装备
        {
            GameObject itemGo = NGUITools.AddChild(parent,equipmentItem);
            itemGo.transform.localPosition = Vector3.zero;
            itemGo.GetComponent<EquipmentItem>().SetInfo(info);
        }
        UpdateProperty();
        return true;
    }

    public void TakeOff(int id,GameObject go)
    {
        Inventory._instance.GetId(id, 1);
        GameObject.DestroyImmediate(go);
        UpdateProperty();
    }
    void UpdateProperty()
    {
        this.attack = 0;
        this.def = 0;
        this.speed = 0;
        EquipmentItem headgearItem = headgear.GetComponentInChildren<EquipmentItem>();
        PlusProperty(headgearItem);
        EquipmentItem armorItem = armor.GetComponentInChildren<EquipmentItem>();
        PlusProperty(armorItem);
        EquipmentItem leftHandItem = leftHand.GetComponentInChildren<EquipmentItem>();
        PlusProperty(leftHandItem);
        EquipmentItem rightHandItem = rightHand.GetComponentInChildren<EquipmentItem>();
        PlusProperty(rightHandItem);
        EquipmentItem shoeItem = shoe.GetComponentInChildren<EquipmentItem>();
        PlusProperty(shoeItem);
        EquipmentItem accessoryItem = accessory.GetComponentInChildren<EquipmentItem>();
        PlusProperty(accessoryItem);
        PlayerStatus._instance.UpdateShow();

    }

    void PlusProperty(EquipmentItem item)
    {
        if(item != null)
        {
            Item equipmentInfo = ItemsInfo.GetItemInfoById(item.id);
            this.attack += equipmentInfo.attack;
            this.def += equipmentInfo.def;
            this.speed += equipmentInfo.speed;
        }
    }

}

